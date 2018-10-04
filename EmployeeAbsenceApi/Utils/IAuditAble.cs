using System;

namespace HRSystemApi.Utils
{
    public interface IAuditAble
    {
        String CreatedBy {get;set;}
        DateTime CreatedDate {get;set;} 
        String UpdatedBy{get;set;}
        DateTime UpdatedDate{get;set;}
        
    }
}