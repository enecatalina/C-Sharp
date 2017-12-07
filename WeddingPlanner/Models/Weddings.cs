using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WeddingPlanner.Models;

namespace WeddingPlanner.Models
{
    public class Weddings : BaseEntity
    {
        public Weddings()
        {
            Guests = new List<RSVP>();
        }
        [Key]
        public int idWedding { get; set; }
        public int idUser { get; set; }

        public Users host { get; set; }
        public string Bride { get; set; }

        public string Groom { get; set; }

        public DateTime Date { get; set; }
        public string Address { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        
        public List<RSVP> Guests { get; set; }

    }

}