using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystemApi.Utils
{
    public abstract class BaseModel: IAuditAble{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        public bool IsDeleted{get;set;}
        public DateTime CreatedDate{get;set;}
        public string CreatedBy{get;set;}
        public DateTime UpdatedDate{get;set;}
        public string UpdatedBy{get;set;}
    }
}