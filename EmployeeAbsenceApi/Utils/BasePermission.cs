using System;

namespace HRSystemApi.Utils
{
    public abstract class BasePermission:BaseModel,IBasePermission
    {
        public string Name {get;set;}
        public string Description {get;set;}
        public DateTime Start {get;set;}
        public DateTime End {get;set;}
        public string ApprovedBy {get;set;}
        public DateTime ApprovedDate {get;set;}
        public string Type {get;set;}
        public virtual string Status {get;set;}
        public virtual int StatusCode {get;set;}
    }
}