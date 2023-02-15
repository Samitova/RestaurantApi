using Restaurant.Domain.Common.Entities;
using Restaurant.Domain.Common.Models;
using Restaurant.Domain.Dinner.ValueObjects;
using Restaurant.Domain.DinnerAggregate.Entities;
using Restaurant.Domain.Host.ValueObjects;
using Restaurant.Domain.Menu.ValueObjects;

namespace Restaurant.Domain.DinnerAggregate;
public sealed class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<Reservation> _reservations = new();
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public DateTime? StartedDateTime { get; private set; } = null;
    public DateTime? EndedDateTime { get; private set; } = null;
    public DinnerStatus DinnerStatus { get; set; }
    public bool IsPublic { get; private set; }
    public int MaxGuests { get; set; }    
    public Price Price { get; private set; }
    public HostId HostId { get; private set; }
    public MenuId MenuId { get; private set; }
    public string ImageUrl { get; set; }
    public Location Location { get; set; }   
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

    private Dinner()
    { }
    private Dinner(
        DinnerId dinnerId,
        string title,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DinnerStatus dinnerStatus,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location,       
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(dinnerId)
    {
        Title = title;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        DinnerStatus = dinnerStatus;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Dinner Create(
        string title,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DinnerStatus dinnerStatus,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location)
    {
        return new(
            DinnerId.CreateUnique(),
            title,
            description,
            startDateTime,
            endDateTime,
            dinnerStatus,
            isPublic,
            maxGuests,
            price,   
            hostId,
            menuId,
            imageUrl,
            location,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
