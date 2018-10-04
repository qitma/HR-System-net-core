using System;
namespace  HRSystemApi.Utils
{
    public interface IBasePermission
    {
        string Name {get;set;}
        string Description {get;set;}
        DateTime Start {get;set;}
        DateTime End {get;set;}
        string ApprovedBy {get;set;}
        DateTime ApprovedDate {get;set;}
        
    }
}