using Restaurant.Application.Common.Interfaces.Persistence;
using Restaurant.Domain.UserAggregate;

namespace Restaurant.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private List<User> _users = new List<User>();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.FirstOrDefault(x => x.Email == email);
    }
}
