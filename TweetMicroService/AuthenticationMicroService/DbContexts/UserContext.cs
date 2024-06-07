using AuthenticationMicroService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationMicroService.DbContexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
