using System;
using System.ComponentModel.DataAnnotations;

namespace Nh.Domain
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Text { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
