using Microsoft.EntityFrameworkCore;
using TweetMicroService.Entities;

namespace TweetMicroService.DbContexts
{
    public class CommentsContext : DbContext
    {
        public CommentsContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Comment> Comments { get; set; }
    }
}
