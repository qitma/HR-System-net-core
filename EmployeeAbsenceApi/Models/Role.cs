using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EmployeeAttendanceApi.Utils;

namespace EmployeeAttendanceApi.Models
{
    public class Role:BaseModel
    {
        public string Name {get;set;}
        public string Description {get;set;}
        public ICollection<UserRole> Users{get;set;}

    }
}