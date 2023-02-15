using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Menu;

namespace Restaurant.Infrastructure.Persistence;

public class RestaurantDbContext: DbContext
{
	public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options):base(options)
	{
	}
	public DbSet<Menu> Menus { get; set; } = null!;
}
