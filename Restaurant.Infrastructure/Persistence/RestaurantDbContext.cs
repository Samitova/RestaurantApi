using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Common.Models;
using Restaurant.Domain.MenuAggregate;
using Restaurant.Infrastructure.Persistence.Interceptors;

namespace Restaurant.Infrastructure.Persistence;

public class RestaurantDbContext: DbContext
{
    private readonly PublishDomainEventsInterseptor _publishDomainEventsInterseptor;
	public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options,
        PublishDomainEventsInterseptor publishDomainEventsInterseptor) :base(options)
	{
        _publishDomainEventsInterseptor= publishDomainEventsInterseptor;
	}
	public DbSet<Menu> Menus { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(RestaurantDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterseptor);
        base.OnConfiguring(optionsBuilder); 
    }
}
