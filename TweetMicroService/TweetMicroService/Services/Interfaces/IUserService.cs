using TweetMicroService.Entities;

namespace TweetMicroService.Services.Interfaces
{
    public interface IUserService
    {
        User GetUser(Guid id);
    }
}
