using TweetMicroService.DbContexts;
using TweetMicroService.Entities;
using TweetMicroService.Services.Interfaces;

namespace TweetMicroService.Services
{
    public class UserService : IUserService
    {
        private readonly UserContext _userContext;

        public UserService(UserContext userContext)
        {
            _userContext = userContext;
        }

        public User GetUser(Guid id)
        {
            return _userContext.Users.Where(u=>u.ID == id).First();
        }
    }
}
