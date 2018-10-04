using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HRSystemApi.Utils;

namespace HRSystemApi.Models
{
    public class Role:BaseModel
    {
        public string Name {get;set;}
        public string Description {get;set;}
        public ICollection<UserRole> Users{get;set;}

    }
}