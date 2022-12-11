using RentME.Models;
using Microsoft.EntityFrameworkCore;

namespace RentME.Data
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public DbSet<User> users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Car>().ToTable("Car");
            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<Rented>().ToTable("Rented");
        }
    }
}
