using System;
using System.ComponentModel.DataAnnotations;

namespace REST.Models
{
    public class UserReview
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Reviewer { get; set; }

        [Required]
        public string Restaurants { get; set; }

        [Required]
        public string Review { get; set; }

        [Required]
        public DateTime Visit { get; set; }

        [Required]
        public int Stars { get; set; }
    }
}