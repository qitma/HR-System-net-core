using System;
using System.Collections.Generic;

namespace HRSystemApi.Utils
{
    public class ValidationResult
    {
        public Dictionary<string,string> Errors {get;set;}
        public bool IsValid {
            get
            {
                return Errors.Count != 0;
            }
        }
    }
    
    public class ValidationException : Exception
    {
        public IEnumerable<ValidationResult> Errors {get;set;}
        public ValidationException(IEnumerable<ValidationResult> errors , string message) : base(message)
        {
            this.Errors = errors;
        }
    }
}