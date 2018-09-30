using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EmployeeAttendanceApi.Utils;

namespace EmployeeAttendanceApi.Models
{
    public class AnnualLeaveUser : BaseModel
    {
        public User User {get;set;}
        public int TotalAnnualLeave {get;set;}
        public int CurrentAnnualLeave {get;set;}

    }
}