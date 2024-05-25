using Microsoft.EntityFrameworkCore;
using TweetMicroService.Entities;

namespace TweetMicroService.DbContexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}