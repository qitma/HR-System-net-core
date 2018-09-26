using EmployeeAttendanceApi.Utils;
using System;

namespace EmployeeAttendanceApi.Models
{
    public class SickLeavePermission:BasePermission
    {
        public string ProofOfSickness {get;set;}
        public int TotalDays {
            get
            {
                return (int)this.GetDatedDiffAsDays();
            }
        }
    }
}