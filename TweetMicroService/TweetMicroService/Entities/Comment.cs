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
        public Guid TweetId { get; set; }
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public string CommentText { get; set; } = string.Empty;
    }
}
