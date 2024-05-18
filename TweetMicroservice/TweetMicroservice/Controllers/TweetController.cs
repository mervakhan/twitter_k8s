using Microsoft.AspNetCore.Mvc;
using TweetMicroservice.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace TweetMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetController : Controller
    {
        private static List<Tweet> tweets = new List<Tweet>
        {
            
            new Tweet { Id = 1, Content = "This is a sample tweet 1", CreatedAt = DateTime.Now },
            new Tweet { Id = 2, Content = "This is a sample tweet 2", CreatedAt = DateTime.Now.AddDays(-1) },
            new Tweet { Id = 3, Content = "This is a sample tweet 3", CreatedAt = DateTime.Now.AddDays(-2) }
            // Add more sample tweets as needed
        

        };
        private static int _nextTweetId = 1;



        // GET: api/Tweetss
        [HttpGet]
        public ActionResult<IEnumerable<Tweet>> Get()
        {
            return Ok(tweets);
        }

        // GET: api/Tweet/5
        [HttpGet("{id}")]
        public ActionResult<Tweet> Get(int id)
        {
            var tweet = tweets.Find(t => t.Id == id);
            if (tweet != null)
            {
                return Ok(tweet);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Tweet
        [HttpPost]
        public ActionResult<Tweet> Post([FromBody] Tweet tweet)
        {
            tweet.Id = _nextTweetId;
            tweet.CreatedAt = DateTime.Now;
            tweets.Add(tweet);
            _nextTweetId++;
            return CreatedAtAction(nameof(Get), new { id = tweet.Id }, tweet);
        }

        // PUT: api/Tweet/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Tweet tweet)
        {
            var index = tweets.FindIndex(t => t.Id == id);
            if (index != -1)
            {
                tweet.Id = id;
                tweet.CreatedAt = tweets[index].CreatedAt;
                tweets[index] = tweet;
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Tweet/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var index = tweets.FindIndex(t => t.Id == id);
            if (index != -1)
            {
                tweets.RemoveAt(index);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}