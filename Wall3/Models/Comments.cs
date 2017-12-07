using System;
using System.ComponentModel.DataAnnotations;

namespace Wall2.Models
{
    public class Comments
    {
        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string Message { get; set; }
        public DateTime Created_at { get; set; }

        public DateTime Updated_at { get; set; }
        public int Users_id { get; set; }
        public int Messages_id { get; set; }
    }
}