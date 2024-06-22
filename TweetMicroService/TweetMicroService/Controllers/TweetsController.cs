using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TweetMicroService.DbContexts;
using TweetMicroService.Entities;
using TweetMicroService.Services.Interfaces;

namespace TweetMicroService.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("[controller]")]
    public class TweetsController : ControllerBase
    {
        private readonly ITweetService _tweetService;
        private readonly IUserService _userService;
        private readonly ICommentService _commentService;

        private readonly ILogger<TweetsController> _logger;

        public TweetsController(ILogger<TweetsController> logger, IUserService userService, 
            ITweetService tweetService, ICommentService commentService)
        {
            _logger = logger;
            _userService = userService;
            _tweetService = tweetService;
            _commentService = commentService;
        }

        [HttpGet("tweets")]
        [Authorize]
        public IActionResult Get()
        {
            var userIdFromClaim = User.Claims.First(n => n.Type == "UserId")?.Value;
            if(Guid.TryParse(userIdFromClaim, out Guid userId))
            {
                var tweets =  _tweetService.Get();
                return Ok(tweets);
            };
            return Unauthorized();        
        }

        [HttpGet("comments")]
        [Authorize]
        public IActionResult GetComments([FromBody] Guid tweetId)
        {
            var userIdFromClaim = User.Claims.First(n => n.Type == "UserId")?.Value;
            if (Guid.TryParse(userIdFromClaim, out Guid userId))
            {
                var comments = _commentService.Get(tweetId);
                return Ok(comments);
            };
            return Unauthorized();
        }

        [HttpPost("createtweets")]
        [Authorize]
        public IActionResult CreateTweet([FromBody] string message)
        {
            var userIdFromClaim = User.Claims.First(n => n.Type == "UserId")?.Value;
            if (Guid.TryParse(userIdFromClaim, out Guid userId))
            {
                 _tweetService.CreateTweet(userId, message);
                return Ok();
            };
            return Unauthorized();
        }

        [HttpPost("createcomments")]
        [Authorize]
        public IActionResult CreateComment([FromBody] Comment comment )
        {
            var userIdFromClaim = User.Claims.First(n => n.Type == "UserId")?.Value;
            if (Guid.TryParse(userIdFromClaim, out Guid userId))
            {
                _commentService.CreateComment(userId, comment.TweetId, comment.CommentText);
                return Ok();
            };
            return Unauthorized();
        }
    }
}
