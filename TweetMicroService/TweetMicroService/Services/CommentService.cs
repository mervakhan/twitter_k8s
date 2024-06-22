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

        public void CreateComment(Guid userId, Guid tweetId, string message)
        {
            var comment = new Comment()
            {
                CommentText = message,
                UserId = userId,
                TweetId = tweetId
            };
            _commentsContext.Comments.Add(comment);
            _commentsContext.SaveChanges();
        }

        public List<Comment> Get(Guid tweetId)
        {
            return _commentsContext.Comments.Where(c=> c.TweetId == tweetId).ToList();
        }
    }
}
