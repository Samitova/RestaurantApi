using Restaurant.Domain.BillAggregate.ValueObjects;
using Restaurant.Domain.Common.Models;
using Restaurant.Domain.Dinner.ValueObjects;
using Restaurant.Domain.GuestAggregate.ValueObjects;
using Restaurant.Domain.Host.ValueObjects;
using Restaurant.Domain.Menu.ValueObjects;
using Restaurant.Domain.MenuReview.ValueObjects;
using Restaurant.Domain.UserAggregate.ValueObjects;

namespace Restaurant.Domain.GuestAggregate;
public sealed class Guest : AggregateRoot<GuestId>
{
    private readonly List<DinnerId> _upcomingDinnerIds = new();
    private readonly List<DinnerId> _pastDinnerIds = new();
    private readonly List<DinnerId> _pendingDinnerIds = new();
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string ProfileImage { get; private set; }
    public float AverageRating { get; private set; }
    public UserId UserId { get; private set; }
    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Guest()
    { }
    private Guest(
        GuestId guestId,
        string firstName,
        string lastName,
        string profileImage,
        float averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime
        )
       : base(guestId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Guest Create(
        string firstName,
        string lastName,
        string profileImage,
        float averageRating,
        UserId userId)
    {
        return new(
            GuestId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            averageRating,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
