using Restaurant.Domain.Common.Models;
using Restaurant.Domain.Dinner.ValueObjects;
using Restaurant.Domain.Host.ValueObjects;
using Restaurant.Domain.Menu.ValueObjects;
using Restaurant.Domain.UserAggregate.ValueObjects;

namespace Restaurant.Domain.HostAggregate;

public sealed class Host : AggregateRoot<HostId>
{
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuId> _menuIds = new();
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string ProfileImage { get; private set; }   
    public float AverageRating { get; private set; }    
    public UserId UserId { get; private set; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Host()
    { }
    private Host(
        HostId hostId,
        string firstName,
        string lastName,
        string profileImage,
        float averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime
        )
       : base(hostId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Host Create(
        string firstName,
        string lastName,
        string profileImage,
        float averageRating,
        UserId userId)
    {
        return new(
            HostId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            averageRating,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
