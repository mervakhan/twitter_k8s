using TweetMicroService.DbContexts;
using TweetMicroService.Entities;
using TweetMicroService.Services.Interfaces;

namespace TweetMicroService.Services
{
    public class TweetService : ITweetService
    {
        private readonly TweetsContext _tweetsContext;

        public TweetService(TweetsContext tweetsContext)
        {
            _tweetsContext = tweetsContext;
        }

        public void CreateTweet(User user, string message)
        {
            var tweet = new Tweet()
            {
                TweetText = message,
                User = user
            };
            _tweetsContext.Tweets.Add(tweet);
            _tweetsContext.SaveChanges();
        }

        public List<Tweet> Get()
        {
            return _tweetsContext.Tweets.ToList();
        }
    }
}
