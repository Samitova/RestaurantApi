using Restaurant.Domain.Common.Models;
using Restaurant.Domain.Dinner.ValueObjects;
using Restaurant.Domain.Host.ValueObjects;
using Restaurant.Domain.MenuAggregate.Entities;
using Restaurant.Domain.MenuAggregate.Events;
using Restaurant.Domain.MenuAggregate.ValueObjects;
using Restaurant.Domain.MenuReview.ValueObjects;

namespace Restaurant.Domain.MenuAggregate;
public sealed class Menu:AggregateRoot<MenuId, Guid>
{    
    private readonly List<MenuSection> _sections = new();

    private readonly List<DinnerId> _dinnerIds = new();

    private readonly List<MenuReviewId> _menuReviewIds = new();
    public string Title { get; private set; }
    public string Description { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public HostId HostId { get; private set; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();    
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Menu()
    { }

    private Menu(
        MenuId menuId, 
        string title, 
        string description,
        AverageRating averageRating, 
        List<MenuSection> sections,
        HostId hostId, 
        DateTime createdDateTime, 
        DateTime updatedDateTime)
        :base(menuId)
    {       
        Title = title;
        Description = description;
        AverageRating = averageRating;
        _sections = sections;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Menu Create(
        string title, 
        string description,
        List<MenuSection> sections,
        HostId hostId)
    {
        var menu = new Menu(
            MenuId.CreateUnique(),
            title,
            description,
            AverageRating.Create(0, 0),
            sections ?? new(),
            hostId, 
            DateTime.UtcNow,
            DateTime.UtcNow);

        menu.AddDomainEvent(new MenuCreated(menu));

        return menu;
    }
}
