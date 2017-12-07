using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Models
{
    public class WedPlannerContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public WedPlannerContext(DbContextOptions<WedPlannerContext> options) : base(options) { }
        //     public DbSet<[What you name the model object]>[The table name you want to link it to]{ get; set; }
        // IMPORTANT NOTE!!!
        // You must have this set to "public" otherwise you will get a protection level error and you won't be able to access the table
        public DbSet<Users> Users { get; set; }
        public DbSet<Weddings> weddings { get; set; }
        public DbSet<RSVP> rsvp { get; set; }
        // This DbSet contains "<Person>" objects and is called "Users"
        //<> is what is generated in the models 
        //the "white" OR "Users" is what is it names in the database/postgre
    }
}