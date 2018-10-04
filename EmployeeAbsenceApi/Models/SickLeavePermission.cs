using HRSystemApi.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRSystemApi.Models
{
    public class SickLeavePermission:BasePermission
    {
        public string ProofOfSickness {get;set;}

    }
}