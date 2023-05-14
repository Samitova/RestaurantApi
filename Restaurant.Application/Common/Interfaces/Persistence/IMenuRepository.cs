using Restaurant.Domain.MenuAggregate;

namespace Restaurant.Application.Common.Interfaces.Persistence;
public interface IMenuRepository
{
    void Add(Menu menu);
}
