
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HRSystemApi.Utils;

namespace HRSystemApi.Models
{
    public class User : BaseModel
    {
        public string Code {get;set;}
        public string Name {get;set;}
        public string FullName {get;set;}
        public string PhoneNumber {get;set;}
        public string Email {get;set;}
        public ICollection<UserRole> Roles{get;set;}
    }
}