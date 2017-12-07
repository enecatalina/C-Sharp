using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WeddingPlanner.Models;

namespace WeddingPlanner.Models
{
    public class RSVP : BaseEntity
    {
        [Key]
        public int idRSVP { get; set;}
        public int idUser {get; set;}
        public int idWedding { get; set; }
        public Weddings Wedding { get; set; }
        public Users Guest { get; set; }
    }
}