using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace TweetMicroService.Entities
{
    public class Tweet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string TweetText { get; set; }

        public ICollection<Comment> Comments { get; set; }
                    = new List<Comment>();
    }
}
