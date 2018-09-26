using EmployeeAttendanceApi.Utils;
using System;

namespace EmployeeAttendanceApi.Models
{
    public class OverTimePermission:BasePermission
    {
        public int TransportReimbursement {get;set;}
        public int MealReimbursement {get;set;}
        public int TotalHours {
            get
            {
                return (int)Math.Round(this.GetDatedDiffAsHours(),0,MidpointRounding.AwayFromZero);
            }
        }
    }
}