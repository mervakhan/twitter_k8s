using Microsoft.EntityFrameworkCore;
using TweetMicroService.Entities;

namespace TweetMicroService.DbContexts
{
    public class TweetsContext : DbContext
    {
        public TweetsContext(DbContextOptions<TweetsContext> options) : base(options)
        {
        }

        public DbSet<Tweet> Tweets { get; set; }
    }
}
