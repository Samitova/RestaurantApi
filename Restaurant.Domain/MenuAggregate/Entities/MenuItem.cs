using Restaurant.Domain.Common.Models;
using Restaurant.Domain.Menu.ValueObjects;

namespace Restaurant.Domain.Menu.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Title { get; private set; }
    public string Description { get; private set; }

    private MenuItem()
    { }
    private MenuItem(MenuItemId menuItemId, string title, string description): base(menuItemId)
    {
        Title = title;
        Description = description;
    }

    public static MenuItem Create(string title, string description)
    {
        return new(MenuItemId.CreateUnique(), title, description);        
    }

}
