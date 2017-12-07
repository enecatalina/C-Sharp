using Microsoft.EntityFrameworkCore;

namespace RESTauranter.Models
{
    public class ReviewsContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public ReviewsContext(DbContextOptions<ReviewsContext> options) : base(options) { }
        //     public DbSet<[What you name the model object]>[The table name you want to link it to]{ get; set; }
        // IMPORTANT NOTE!!!
        // You must have this set to "public" otherwise you will get a protection level error and you won't be able to access the table
        public DbSet<Reviews> Review { get; set; }
    }
}