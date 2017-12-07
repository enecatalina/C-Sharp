using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelBuddy.Models;

namespace TravelBuddy.Models
{
    public class Trips : BaseEntity
    {
        public Trips()
        {
            Buddies = new List<Buddies>();
        }
        [Key]
        public int idTrip { get; set; }
        public int idUser { get; set; }
        public Users Host { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Buddies> Buddies { get; set; }
    }
}