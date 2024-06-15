using AuthenticationMicroService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationMicroService.DbContexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.ID); // Specify the primary key
                                        // Additional configuration if needed
        }
    }
}
