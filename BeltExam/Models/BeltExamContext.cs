using Microsoft.EntityFrameworkCore;

namespace BeltExam.Models
{
    public class BeltExamContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public BeltExamContext(DbContextOptions<BeltExamContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Auctions> Auctions { get; set; }

        public DbSet<Bids> Bids { get; set; }
        
    }
}