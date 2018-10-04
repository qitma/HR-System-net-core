using HRSystemApi.Utils;
using HRSystemApi.Models;
using HRSystemApi.Context;
using HRSystemApi.Constants;
using HRSystemApi.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace HRSystemApi.Services
{
    public class AttendanceService : BaseService<Attendance>, IAttendanceService
    {
        public AttendanceService(HRSystemContext dbContext, string actor) : base(dbContext, actor)
        {
        }

        protected override Attendance BeforeUpdate(Attendance local, Attendance db)
        {
            db.Name += string.Empty;

            return db;
        }

        protected override IEnumerable<ValidationResult> Validate(Attendance model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                yield return new ValidationResult()
                {
                    Errors = new Dictionary<string, string>
                            {
                                {"Name","Name must not  be empty"}
                            }
                };
            }

            if (model.TimeOut.HasValue && model.TimeOut < model.TimeIn)
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
                .FirstOrDefault(x => x.UserCode == userId && x.TimeIn.Date == today);
        }

        private User GetUserByCode(string code)
        {
            return base._dbContext.Set<User>().FirstOrDefault(x => x.Code == code);
        }

        private void AttendanceIn(DateTime timeIn, User user)
        {
            try
            {
                Attendance _attendance = new Attendance()
                {
                    Name = user.Name,
                    TimeIn = timeIn,
                    Status = AttendanceConstant.TimeIn,
                    UserCode = user.Code,

                };
                base.Create(_attendance);

            }
            catch (Exception)
            {
                throw;
            }


        }

        private void AttendanceOut(DateTime timeOut, Attendance attendance)
        {
            try
            {
                attendance.TimeOut = timeOut;
                attendance.Status = AttendanceConstant.TimeOut;
                base.Update(attendance);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Attendance(DateTime timeAttend, string userCode)
        {
            try
            {
                Attendance _exist = GetCurrentAttendanceByUserId(userCode);
                if (_exist == null)
                {
                    User _user = GetUserByCode(userCode);
                    if (_user == null)
                        throw new Exception("User is null");
                    AttendanceIn(timeAttend, _user);
                }
                else
                {
                    AttendanceOut(timeAttend,_exist);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}