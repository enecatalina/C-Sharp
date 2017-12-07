using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelBuddy.Models;

namespace TravelBuddy.Models
{

    public class Users : BaseEntity
    {
        public Users()
        {
            Trips = new List<Trips>();
            Buddies = new List<Buddies>();

        }
        [Key]
        public int idUser { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public List<Trips> Trips { get; set; }
        public List<Buddies> Buddies { get; set; }

    }

}