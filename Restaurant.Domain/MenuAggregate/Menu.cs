using Restaurant.Domain.Common.Models;
using Restaurant.Domain.Dinner.ValueObjects;
using Restaurant.Domain.Host.ValueObjects;
using Restaurant.Domain.Menu.Entities;
using Restaurant.Domain.Menu.ValueObjects;
using Restaurant.Domain.MenuReview.ValueObjects;

namespace Restaurant.Domain.Menu;

public sealed class Menu:AggregateRoot<MenuId>
{    
    private readonly List<MenuSection> _sections = new();

    private readonly List<DinnerId> _dinnerIds = new();

    private readonly List<MenuReviewId> _menuReviewId = new();
    public string Title { get; }
    public string Description { get; }
    public float AverageRating { get; }
    public IReadOnlyList<MenuSection> Sections=> _sections.AsReadOnly();
    public HostId HostId { get; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewId => _menuReviewId.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Menu(
        MenuId menuId, 
        string title, 
        string description, 
        float averageRating, 
        HostId hostId, 
        DateTime createdDateTime, 
        DateTime updatedDateTime)
        :base(menuId)
    {       
        Title = title;
        Description = description;
        AverageRating = averageRating;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Menu Create(
        string title, 
        string description,
        float averageRating,
        HostId hostId)
    {
        return new(
            MenuId.CreateUnique(),
            title,
            description,
            averageRating,
            hostId, 
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
