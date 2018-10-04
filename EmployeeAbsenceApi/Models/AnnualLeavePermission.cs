using HRSystemApi.Utils;
using HRSystemApi.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HRSystemApi.Models
{
    public class AnnualLeavePermission:BasePermission
    {
        public int TransportReimbursement {get;set;}
        public int MealReimbursement {get;set;}
        public int TotalDays {get;set;}
    }
}