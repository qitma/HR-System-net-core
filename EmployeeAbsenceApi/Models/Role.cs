using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EmployeeAttendanceApi.Utils;

namespace EmployeeAttendanceApi.Models
{
    public class Role:BaseModel,IValidatableObject{
        public string Name {get;set;}
        public string Description {get;set;}
        public ICollection<UserRole> Users{get;set;}

           public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(String.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name must not be empty",new List<String>(){"Name"});
            }

            if(String.IsNullOrEmpty(Description))
            {
                yield return new ValidationResult("Description must not be empty",new List<String>(){"Description"});
            }

        }
    }
}