using System;
using System.ComponentModel.DataAnnotations;

namespace Nh.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public Int64 Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
