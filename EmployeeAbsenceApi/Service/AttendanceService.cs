using EmployeeAttendanceApi.Utils;
using EmployeeAttendanceApi.Models;
using EmployeeAttendanceApi.Context;
using EmployeeAttendanceApi.Constant;
using System.Collections.Generic;
using System.Linq;
using System;

namespace EmployeeAttendanceApi.Service
{
    public class AttendanceService : BaseService<Attendance>
    {
        public AttendanceService(AttendanceContext dbContext, string actor) : base(dbContext,actor)
        {
        }

        protected override Attendance BeforeUpdate(Attendance local, Attendance db)
        {
            db.Name += string.Empty;
            
            return db;
        }

        protected override IEnumerable<ValidationResult> Validate(Attendance model)
        {
            if(string.IsNullOrEmpty(model.Name))
            {
                yield return new ValidationResult()
                    {
                        Errors = new Dictionary<string, string>
                            {
                                {"Name","Name must not  be empty"}
                            }
                    };
            }

            if(model.TimeOut.HasValue && model.TimeOut < model.TimeIn)
            {
                yield return new ValidationResult()
                {
                    Errors = new Dictionary<string, string>
                    {
                        {"TimeOut","TimeOut must greater than TimeIn"}
                    }
                };
            }
        }

        private Attendance GetCurrentAttendanceByUserId(string userId)
        {
            DateTime today = DateTime.UtcNow.Date;
            return base._dbContext.Set<Attendance>()
                .FirstOrDefault(x=> x.UserCode == userId && x.TimeIn.Date == today);
        }

        private User GetUserByCode(string code)
        {
            return base._dbContext.Set<User>().FirstOrDefault(x=> x.Code == code);
        }

        public void AttendanceIn(string userId)
        {
            var _exist = GetCurrentAttendanceByUserId(userId);
            if(_exist == null)
            {
                User _user = GetUserByCode(userId);
                Attendance _attendance = new Attendance()
                {
                    Name = _user.Name,
                    TimeIn = DateTime.UtcNow,
                    Status = AttendanceConstant.TimeIn
                };

                base.Create(_attendance);
            }
        }

        public void AttendanceOut(string userId)
        {
            var _exist = GetCurrentAttendanceByUserId(userId);
            if(_exist != null)
            {
                User _user = GetUserByCode(userId);
                Attendance _attendance = new Attendance()
                {
                    Name = _user.Name,
                    TimeOut = DateTime.UtcNow,
                    Status = AttendanceConstant.TimeIn
                };

                base.Create(_attendance);
            }
        }
    }
}