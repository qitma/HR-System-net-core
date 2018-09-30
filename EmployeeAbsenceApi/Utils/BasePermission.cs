using System;

namespace EmployeeAttendanceApi.Utils
{
    public abstract class BasePermission:BaseModel
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
        public BasePermission()
        {

        }

        protected virtual double GetDatedDiffAsDays()
        {
            return (this.End - this.Start).TotalDays;
        }

        protected virtual double GetDatedDiffAsHours()
        {
            return (this.End - this.Start).TotalHours;
        }
    }
}