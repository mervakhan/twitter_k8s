using Microsoft.EntityFrameworkCore;
using TweetMicroService.Entities;

namespace TweetMicroService.DbContexts
{
    public class CommentsContext : DbContext
    {
        public CommentsContext(DbContextOptions<CommentsContext> options) : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }
    }
}
