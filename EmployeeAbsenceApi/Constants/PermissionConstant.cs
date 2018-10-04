using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HRSystemApi.Constants
{
    public  class PermissionConstant{
        public const int HALF_DAY_THRESHOLD = 4;
        public static  ReadOnlyCollection<string> ROLE_CAN_ACCEPT = new ReadOnlyCollection<string>(
            new []{
                "Human Resources",
                "Project Manager",
                "Chief Technology Officer"
            }
        );
    }
}