using System;
using System.Collections.Generic;
using HRSystemApi.Models;

namespace HRSystemTest.DataUtil
{
    public class AttendanceDataUtil
    {
        public Attendance GetAttendanceUtil(DateTime? TimeIn, DateTime? TimeOut , string userCode)
        {
            return new Attendance()
            {
                Id = 0,
                Name = "Test",
                TimeIn = TimeIn ?? DateTime.UtcNow,
                TimeOut = TimeOut,
            };
        }
    }
}