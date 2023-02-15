using Restaurant.Application.Common.Interfaces.Persistence;
using Restaurant.Domain.Menu;

namespace Restaurant.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private static readonly RestaurantDbContext _context;
    public void Add(Menu menu)
    {
        _context.Add(menu);
        _context.SaveChanges();
    }
}
