using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nh.Services.Emails
{
    public class EmailRequest
    {
        [Required]
        public string From { get; set; }
        [Required]
        public IEnumerable<string> To { get; set; }
        public IEnumerable<string> Cc { get; set; }
        public IEnumerable<string> Bcc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
