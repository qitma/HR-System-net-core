using HRSystemApi.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRSystemApi.Models
{
    public class OverTimePermission:BasePermission
    {
        public int TransportReimbursement {get;set;}
        public int MealReimbursement {get;set;}

    }
}