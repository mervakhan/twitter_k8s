namespace TweetMicroservice.Models
{
    public class Tweet
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        // Add other properties as needed

        public static Tweet GetHardcodedTweet()
        {
            return new Tweet
            {
                Id = 1,
                UserId = "user1",
                Content = "This is a hardcoded tweet",
                CreatedAt = DateTime.Now
            };
        }
    }
    
}
