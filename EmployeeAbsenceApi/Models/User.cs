
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EmployeeAttendanceApi.Utils;

namespace EmployeeAttendanceApi.Models
{
    public class User : BaseModel, IValidatableObject
    {
        public string Code {get;set;}
        public string Name {get;set;}
        public string FullName {get;set;}
        public string PhoneNumber {get;set;}
        public string Email {get;set;}
        public ICollection<UserRole> Roles{get;set;}
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if(String.IsNullOrEmpty(Code))
            {
                yield return new ValidationResult("Code must not be empty",new List<String>(){"Code"});
            }

            if(String.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name must not be empty",new List<String>(){"Name"});
            }

            if(String.IsNullOrEmpty(FullName))
            {
                yield return new ValidationResult("FullName must not be empty",new List<String>(){"FullName"});
            }

            if(String.IsNullOrEmpty(PhoneNumber))
            {
                yield return new ValidationResult("PhoneNumber must not be empty",new List<String>(){"PhoneNumber"});
            }
            else if(PhoneNumber.Length <11 || PhoneNumber.Length > 14)
            {
                yield return new ValidationResult("PhoneNumber must be between 11 - 14 digits.",new List<String>(){"PhoneNumber"});
            }

            if(Roles.Count == 0)
            {
                yield return new ValidationResult("User must have at least 1 role.", new List<string>(){"Roles"});
            }
        }
    }
}