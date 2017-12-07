using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WeddingPlanner.Models;

namespace WeddingPlanner.Models
{

    public class Users : BaseEntity
    {
        public Users()
        {
            Weddings = new List<Weddings>();
            Guests = new List<RSVP>();
        }
        [Key]
        public int idUser { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public List<Weddings> Weddings { get; set; }
        public List<RSVP> Guests { get; set; }

    }

}