using System;
using System.Collections.Generic;

namespace HRSystemApi.Enum
{
    public enum AttendanceType
    {
        IN = 0,
        OUT = 1
    }

    [Flags]
    public enum ApprovePermissionType
    {
        HUMAN_RESOURCE = 1,
        PROJECT_MANAGER = 2,
        CHIEF_TECHNOLOGY = 4
    }

    public static class ApproveStatus
    {
        public static  Dictionary<string,ApprovePermissionType> StatusCode {get;private set;}
        public static  Dictionary<string,string> StatusName {get;private set;}
        static ApproveStatus()
        {
            StatusCode = new Dictionary<string, ApprovePermissionType>()
                {
                    {"Human Resource",ApprovePermissionType.HUMAN_RESOURCE},
                    {"Project Manager",ApprovePermissionType.PROJECT_MANAGER},
                    {"Chief Technology Officer",ApprovePermissionType.CHIEF_TECHNOLOGY},
                };
            
            StatusName = new Dictionary<string, string>()
                {
                    {"Human Resource","HR APPROVED"},
                    {"Project Manager","PM APPROVED"},
                    {"Chief Technology Officer","CTO APPROVED"},
                };
        }
    }
}