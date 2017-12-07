using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelBuddy.Models;

namespace TravelBuddy.Models
{
    public class Buddies : BaseEntity
    {
        [Key]
        public int idBuddies { get; set; }
        public int idUser { get; set; }
        public int idTrip { get; set; }
        public Trips Trips { get; set; }
        public Users Buddie { get; set; }
    }
}