using EmployeeAttendanceApi.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAttendanceApi.Models
{
    public class OverTimePermission:BasePermission
    {
        public int TransportReimbursement {get;set;}
        public int MealReimbursement {get;set;}

    }
}