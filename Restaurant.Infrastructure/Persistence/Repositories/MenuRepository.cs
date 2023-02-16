using Restaurant.Application.Common.Interfaces.Persistence;
using Restaurant.Domain.Menu;
using System;

namespace Restaurant.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly RestaurantDbContext _context;    
    public MenuRepository(RestaurantDbContext context)
    {
        _context = context;
    }
    public void Add(Menu menu)
    {
        _context.Add(menu);
        _context.SaveChanges();
    }
}
