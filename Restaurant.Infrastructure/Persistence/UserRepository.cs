using Restaurant.Application.Common.Interfaces.Persistence;
using Restaurant.Domain.Entities;

namespace Restaurant.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    public void Add(User user)
    {
        throw new NotImplementedException();
    }

    public User? GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }
}
