using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HRSystemApi.Utils;

namespace HRSystemApi.Models
{
    public class AnnualLeaveUser : BaseModel
    {
        public User User {get;set;}
        public int TotalAnnualLeave {get;set;}
        public int CurrentAnnualLeave {get;set;}

    }
}