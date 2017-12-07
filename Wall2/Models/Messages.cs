using System;
using System.ComponentModel.DataAnnotations;

namespace Wall2.Models
{
    public class Messages
    {

        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string Message { get; set; }
        public DateTime Created_at { get; set; }

        public DateTime Updated_at { get; set; }
        public int Users_id { get; set; }
    }
}