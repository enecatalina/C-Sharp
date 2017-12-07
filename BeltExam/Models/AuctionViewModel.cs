using System.ComponentModel.DataAnnotations;
using System;
using BeltExam.Models; 

namespace BeltExam.Models
{
    public class AuctionViewModel : BaseEntity
    {
        [Required]
        [MinLength(3, ErrorMessage = "Product Name must be more than 2 characters!")]
        public string Product { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = " Description must be more than 10 characters!")]
        public string Description { get; set; }

        [Required(ErrorMessage ="You most have a starting bid!")]
        public int StartingBid { get; set; }

        [Required(ErrorMessage = "Please file out a End Date for the bid!")]
        public DateTime EndDate { get; set; }

    }
}
