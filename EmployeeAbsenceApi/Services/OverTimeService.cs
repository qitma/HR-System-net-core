using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using HRSystemApi.Utils;
using HRSystemApi.Models;
using HRSystemApi.Interfaces;
using HRSystemApi.Enum;
using HRSystemApi.Context;
using HRSystemApi.Constants;

namespace HRSystemApi.Services
{
    public class OverTimeService : BaseService<OverTimePermission>, IOverTimeService
    {
        public OverTimeService(HRSystemContext dbContext, string actor) : base(dbContext, actor)
        {
        }

        public IBasePermission ApprovePermission(OverTimePermission OverTimeModel ,User Approver , string ApproverAs)
        {
            DateTime today = DateTime.UtcNow;
            try
            {
               if(Approver == null)
                    throw new Exception("Approver must not be empty");
                Role approverRole = GetStatusApproved(Approver.Code,ApproverAs);
                if(approverRole == null)
                    throw new Exception("Approver not have authority");
                OverTimeModel.ApprovedBy = Approver.FullName;
                OverTimeModel.ApprovedDate = today;
                OverTimeModel.StatusCode |= (int)ApproveStatus.StatusCode[approverRole.Name];
                OverTimeModel.Status = ApproveStatus.StatusName[approverRole.Name];
                return base.Update(OverTimeModel);
            }
            catch(Exception)
            {
                throw;
            }
        }

        private Role GetStatusApproved(string approverCode,string approverAs)
        {
            var role = 
                (
                from u in base._dbContext.Users
                join ur in base._dbContext.UserRoles
                    on u.Id equals ur.UserId
                join r in base._dbContext.Roles
                    on ur.RoleId equals r.Id
                where u.Code == approverCode
                && r.Name.ToUpper() == approverAs.ToUpper()
                select r).FirstOrDefault();
            return role;

        }

        protected override IEnumerable<ValidationResult> Validate(OverTimePermission model)
        {
            throw new NotImplementedException();
        }
    }
}