using System.ComponentModel.DataAnnotations;
using System;

namespace TravelBuddy.Models
{
    public class TripsViewModel : BaseEntity
    {
        [Required]
        [MinLength(3, ErrorMessage = ("Enter Your Place Destination"))]
        [Display(Name = "Destinations")]
        public string Destination { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = ("Enter A Description About The Trip "))]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = ("Travel Start Date Is Required"))]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = ("Travel End Date Is Required"))]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

    }
}