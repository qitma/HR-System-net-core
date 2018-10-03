using System;
using Xunit;
using HRSystemTest.DataUtil;
using HRSystemTest.Helper;
using EmployeeAttendanceApi.Context;
using EmployeeAttendanceApi.Models;
using EmployeeAttendanceApi.Interfaces;
using EmployeeAttendanceApi.Service;
using EmployeeAttendanceApi.Constant;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HRSystemTest.Test
{

    public class AttendanceTest
    {
        private const string ACTOR = "TEST_USER";
        [Fact]
        public void Test_Get_Attendance()
        {
            string userCode = "MMH";
            AttendanceDataUtil attendanceUtil = new AttendanceDataUtil();
            HRSystemContext context = ContextMemoryHelper.GetContext("Get_Data_User_Context");
            AttendanceService ats = new AttendanceService(context,ACTOR);
            Attendance attendance = attendanceUtil.GetAttendanceUtil(DateTime.UtcNow,null, userCode);
            ats.Create(attendance);
            Attendance actual = ats.GetById(attendance.Id);
            Assert.NotNull(actual);
            Assert.Equal(attendance.Id,actual.Id);
        }

        [Fact]
        public void Test_Get_All_Attendance()
        {
            AttendanceDataUtil attendanceUtil = new AttendanceDataUtil();
            HRSystemContext context = ContextMemoryHelper.GetContext("Get_All_Data_Context");
            AttendanceService ats = new AttendanceService(context,ACTOR);
            Attendance attendance1 = attendanceUtil.GetAttendanceUtil(DateTime.UtcNow,null, "MMH1");
            Attendance attendance2 = attendanceUtil.GetAttendanceUtil(DateTime.UtcNow,null, "MMH2");
            ats.Create(attendance1);
            ats.Create(attendance2);
            int actual = ats.GetAll().Count();
            int expected = 2;
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void Test_TimeIn_Attendance()
        {
            AttendanceDataUtil attendanceUtil = new AttendanceDataUtil();
            UserDataUtil userUtil = new UserDataUtil();
            HRSystemContext context = ContextMemoryHelper.GetContext("Time_In_Attendance");
            IAttendanceService ats = new AttendanceService(context,ACTOR);

            User user = userUtil.GetUserUtil();
            context.Entry(user).State = EntityState.Added;
            context.Set<User>().Add(user);
            context.SaveChanges();

            DateTime timeIn = DateTime.UtcNow;
            ats.AttendanceIn(timeIn,user.Code);
            
            Attendance currentAtt = context.Set<Attendance>().FirstOrDefault(x => x.UserCode == user.Code);
            
            Assert.NotNull(currentAtt);
            Assert.Equal(timeIn,currentAtt.TimeIn);
            Assert.Equal(AttendanceConstant.TimeIn.ToUpper(),currentAtt.Status.ToUpper());
        }

        [Fact]
        public void Test_TimeOut_Attendance()
        {
            AttendanceDataUtil attendanceUtil = new AttendanceDataUtil();
            UserDataUtil userUtil = new UserDataUtil();
            HRSystemContext context = ContextMemoryHelper.GetContext("Time_Out_Attendance");
            IAttendanceService ats = new AttendanceService(context,ACTOR);

            User user = userUtil.GetUserUtil();
            context.Entry(user).State = EntityState.Added;
            context.Set<User>().Add(user);
            context.SaveChanges();

            DateTime timeIn = DateTime.UtcNow;
            DateTime timeOut = timeIn.AddHours(8);
            ats.AttendanceIn(timeIn,user.Code);
            ats.AttendanceOut(timeOut,user.Code);
            
            Attendance currentAtt = context.Set<Attendance>().FirstOrDefault(x => x.UserCode == user.Code);
            
            Assert.NotNull(currentAtt);
            Assert.Equal(timeOut,currentAtt.TimeOut);
            Assert.Equal(AttendanceConstant.TimeOut.ToUpper(),currentAtt.Status.ToUpper());
        }

    }
}
