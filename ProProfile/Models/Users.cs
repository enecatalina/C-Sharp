using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProProfile.Models;

namespace ProProfile.Models
{

    public class Users : BaseEntity
    {
        public Users()
        {
            Friends = new List<Friends>();
        }
        [Key]
        public int idUser { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Description{ get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public List<Friends> Friends { get; set; }

    }

}