using EmployeeAttendanceApi.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAttendanceApi.Models
{
    public class SickLeavePermission:BasePermission
    {
        public string ProofOfSickness {get;set;}

    }
}