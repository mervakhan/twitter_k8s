using TweetMicroService.Entities;

namespace TweetMicroService.Services.Interfaces
{
    public interface ITweetService
    {
        List<Tweet> Get();
        void CreateTweet(User user, string message);
    }
}
