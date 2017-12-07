using Microsoft.EntityFrameworkCore;
using TravelBuddy.Models;

namespace TravelBuddy.Models
{
    public class TravelBuddyContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public TravelBuddyContext(DbContextOptions<TravelBuddyContext> options) : base(options) { }
        //     public DbSet<[What you name the model object]>[The table name you want to link it to]{ get; set; }
        // IMPORTANT NOTE!!!
        // You must have this set to "public" otherwise you will get a protection level error and you won't be able to access the table
        public DbSet<Users> Users { get; set; }
        public DbSet<Trips> trips { get; set; }
        public DbSet<Buddies> buddies { get; set; }
        // This DbSet contains "<Person>" objects and is called "Users"
        //<> is what is generated in the models 
        //the "white" OR "Users" is what is it names in the database/postgre
    }
}