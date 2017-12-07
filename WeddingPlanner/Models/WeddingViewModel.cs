using System.ComponentModel.DataAnnotations;
using System;

namespace WeddingPlanner.Models
{
    public class WeddingViewModel : BaseEntity
    {
        [Required]
        [MinLength(1, ErrorMessage=("Enter Bride's Name"))]
        [Display(Name = "Bride")]
        public string Bride { get; set; }

        [Required]
        [MinLength(1, ErrorMessage=("Enter Groom's Name"))]
        [Display(Name = "Groom")]
        public string Groom { get; set; }

        [Required(ErrorMessage=("Date is Required"))]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = ("Enter Location"))]
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}