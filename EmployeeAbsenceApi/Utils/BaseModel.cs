using System;

namespace EmployeeAttendanceApi.Utils
{
    public abstract class BaseModel: IAuditAble{
        public int Id {get;set;}
        public bool IsDeleted{get;set;}
        public DateTime CreatedDate{get;set;}
        public string CreatedBy{get;set;}
        public DateTime UpdatedDate{get;set;}
        public string UpdatedBy{get;set;}
    }
}