using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BeltExam.Models;

namespace BeltExam.Models
{

    public class Users : BaseEntity
    {
        public Users()
        {
            Bids = new List<Bids>();
            Auctions = new List<Auctions>();
        }
        [Key]
        public int idUser { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public double Balance { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }


        public List<Bids> Bids { get; set; }
        public List<Auctions> Auctions { get; set; }
    }
}