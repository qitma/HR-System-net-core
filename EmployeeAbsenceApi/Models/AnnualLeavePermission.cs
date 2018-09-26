using EmployeeAttendanceApi.Utils;
using EmployeeAttendanceApi.Constant;
using System;

namespace EmployeeAttendanceApi.Models
{
    public class AnnualLeavePermission:BasePermission
    {
        public int TransportReimbursement {get;set;}
        public int MealReimbursement {get;set;}
        public int TotalDays {
            get
            {
                return (int)this.GetDatedDiffAsDays();
            }
        }

        public bool IsHalfDay 
        {
            get
            {
                return this.GetDatedDiffAsHours() <= PermissionConstant.HALF_DAY_THRESHOLD;
            }
        }
    }
}