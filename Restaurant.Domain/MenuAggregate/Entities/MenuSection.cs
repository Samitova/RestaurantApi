using Restaurant.Domain.Common.Models;
using Restaurant.Domain.Menu.ValueObjects;

namespace Restaurant.Domain.Menu.Entities;

public sealed class MenuSection: Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();
    public string Title { get; private set; }
    public string Description { get; private set; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(MenuSectionId menuSectionId, string title, string description, List<MenuItem> items) : base(menuSectionId)
    {
        Title = title;
        Description = description;
        _items = items;
    }

    public static MenuSection Create(string title, string description, List<MenuItem> items)
    {
        return new(MenuSectionId.CreateUnique(), title, description, items);
    }
}
