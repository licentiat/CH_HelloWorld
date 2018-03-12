using System.ComponentModel.DataAnnotations;

namespace Nh.Data.Entities
{
    public class Message : BaseEntity
    {
        [Required, StringLength(255)]
        public string Text { get; set; }
    }
}
