using TweetMicroService.DbContexts;
using TweetMicroService.Entities;
using TweetMicroService.Services.Interfaces;

namespace TweetMicroService.Services
{
    public class CommentService : ICommentService
    {
        private readonly CommentsContext _commentsContext;

        public CommentService(CommentsContext commentsContext)
        {
            _commentsContext = commentsContext;
        }

        public void CreateComment(User user, Tweet tweet, string message)
        {
            var comment = new Comment()
            {
                CommentText = message,
                User = user,
                Tweet = tweet
            };
            _commentsContext.Comments.Add(comment);
            _commentsContext.SaveChanges();
        }

        public List<Comment> Get(Guid tweetId)
        {
            return _commentsContext.Comments.Where(c=> c.Tweet.ID == tweetId).ToList();
        }
    }
}
