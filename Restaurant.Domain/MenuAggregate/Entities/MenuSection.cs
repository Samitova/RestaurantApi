using Restaurant.Domain.Common.Models;
using Restaurant.Domain.Menu.ValueObjects;

namespace Restaurant.Domain.Menu.Entities;

public sealed class MenuSection: Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();
    public string Title { get; }
    public string Description { get; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(MenuSectionId menuSectionId, string title, string description) : base(menuSectionId)
    {
        Title = title;
        Description = description;
    }

    public static MenuSection Create(string title, string description)
    {
        return new(MenuSectionId.CreateUnique(), title, description);
    }
}
