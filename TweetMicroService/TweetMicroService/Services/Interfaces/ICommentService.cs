using TweetMicroService.Entities;

namespace TweetMicroService.Services.Interfaces
{
    public interface ICommentService
    {
        List<Comment> Get(Guid tweetId);
        void CreateComment(User user,Tweet tweet, string message);
    }
}
