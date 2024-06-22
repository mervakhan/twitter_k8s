using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TweetMicroService.Entities
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [ForeignKey("TweetId")]
        public Tweet Tweet { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string CommentText { get; set; } = string.Empty;
    }
}
