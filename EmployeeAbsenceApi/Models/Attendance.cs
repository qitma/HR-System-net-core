using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EmployeeAttendanceApi.Utils;
using EmployeeAttendanceApi.AbsenceEnum;

namespace EmployeeAttendanceApi.Models
{
    public class Attendance : BaseModel, IValidatableObject
    {
        public string Name {get;set;}
        public string UserCode{get;set;}
        public DateTime TimeIn {get;set;}
        public DateTime TimeOut {get;set;}
        public int StatusCode {get;set;}
        public string Status {
            get
            {
                return ((AttendanceType)this.StatusCode).ToString();
            }
        }
        public User User {get;set;}
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name must not be empty", new List<string>(){"Name"});
            }

            if(string.IsNullOrEmpty(UserCode))
            {
                yield return new ValidationResult("UserCode must not be empty", new List<string>(){"UserCode"});
            }

            if(TimeIn == null || TimeIn == DateTime.MinValue)
            {
                yield return new ValidationResult("TimeIn must not be empty", new List<string>(){"TimeIn"});
            }

            if(!Enum.IsDefined(typeof(AttendanceType),StatusCode))
            {
                 yield return new ValidationResult("StatusCOde is not valid", new List<string>(){"StatusCode"});
            }
        }
    }
}