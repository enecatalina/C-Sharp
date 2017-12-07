using System;
using System.ComponentModel.DataAnnotations;

namespace BeltExam.Models
{
    public class Bids : BaseEntity
    {
        [Key]
        public int idBid { get; set; }
        public double Amount { get; set; }
        public int idUser { get; set; }
        public int idAuction { get; set; }

        public bool HighestBid { get; set; } = false;

        public Users User { get; set; }
        public Auctions Auctions { get; set; }
    }
}