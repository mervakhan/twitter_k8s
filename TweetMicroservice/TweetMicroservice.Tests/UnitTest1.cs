using Xunit;
using TweetMicroservice.Controllers;
using TweetMicroservice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace TweetMicroserviceTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestGetReturnsListOfTweets()
        {
            // Arrange
            var controller = new TweetController();

            // Act
            var result = controller.Get() as ActionResult<IEnumerable<Tweet>>;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result.Result);
            var tweets = Assert.IsAssignableFrom<IEnumerable<Tweet>>(result.Value);
            Assert.NotEmpty(tweets);
        }
    }
}
