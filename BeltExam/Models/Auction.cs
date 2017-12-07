using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BeltExam.Models;

namespace BeltExam.Models
{
    public class Auctions : BaseEntity
    {
        public Auctions()
        {
            Bids = new List<Bids>();
        }
        [Key]
        public int idAuction { get; set; }
        public int idUser { get; set; }
        public string Product { get; set; }
        public string Description { get; set; }
        public float StartingBid { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan TimeRemaining { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Finished { get; set; } = false;

        public Users User { get; set; }
        public List<Bids> Bids { get; set; }
    }
}