using EmployeeAttendanceApi.Utils;
using EmployeeAttendanceApi.Constant;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EmployeeAttendanceApi.Models
{
    public class AnnualLeavePermission:BasePermission
    {
        public AnnualLeavePermission()
        {
        }

        public int TransportReimbursement {get;set;}
        public int MealReimbursement {get;set;}
        public int TotalDays {get;set;}
    }
}