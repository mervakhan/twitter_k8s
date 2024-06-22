using Microsoft.EntityFrameworkCore;
using TweetMicroService.Entities;

namespace TweetMicroService.DbContexts
{
    public class TweetsContext : DbContext
    {
        public TweetsContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Tweet> Tweets { get; set; }
    }
}
