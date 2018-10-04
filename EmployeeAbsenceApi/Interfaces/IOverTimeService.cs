using System;
using HRSystemApi.Utils;
using HRSystemApi.Models;

namespace HRSystemApi.Interfaces
{
    public interface IOverTimeService
    {
        IBasePermission ApprovePermission(OverTimePermission OverTimeModel, User Approver, string ApproverAs);
    }
}