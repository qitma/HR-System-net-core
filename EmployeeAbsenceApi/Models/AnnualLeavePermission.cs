using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using HRSystemApi.Utils;

namespace HRSystem
{
    public class AnnualLeavePermission:BasePermission
    {
        public int TransportReimbursement {get;set;}
        public int MealReimbursement {get;set;}
        public int TotalDays {get;set;}
    }
}