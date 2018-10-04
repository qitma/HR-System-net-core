using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HRSystemApi.Utils;

namespace HRSystemApi.Models
{
    public class Attendance : BaseModel
    {
        [Required]
        [MinLength(4)]
        public string Name {get;set;}
        [Required]
        public string UserCode{get;set;}
        public DateTime TimeIn {get;set;}
        public DateTime? TimeOut {get;set;}
        public int StatusCode {get;set;}
        public string Status {get;set;}
        public User User {get;set;}

    }
}