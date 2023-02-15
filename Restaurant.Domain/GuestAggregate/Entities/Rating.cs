using Restaurant.Domain.BillAggregate.ValueObjects;
using Restaurant.Domain.Common.Models;
using Restaurant.Domain.Dinner.ValueObjects;
using Restaurant.Domain.GuestAggregate.ValueObjects;
using Restaurant.Domain.Host.ValueObjects;

namespace Restaurant.Domain.GuestAggregate.Entities;
public sealed class Rating : Entity<RatingId>
{
    public HostId HostId { get; private set; }   
    public DinnerId DinnerId { get; private set; }
    public int RatingValue { get; set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Rating()
    { }

    private Rating(   
        RatingId ratingId,
        HostId hostId,       
        DinnerId dinnerId,
        int ratingValue,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(ratingId)
    {
        HostId = hostId;        
        DinnerId = dinnerId;
        RatingValue = ratingValue;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Rating Create(
        HostId hostId,       
        DinnerId dinnerId,
        int ratingValue
        )
    {
        return new(
            RatingId.CreateUnique(),
            hostId,           
            dinnerId,
            ratingValue,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
