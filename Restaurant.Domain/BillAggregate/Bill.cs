using Restaurant.Domain.BillAggregate.ValueObjects;
using Restaurant.Domain.Common.Models;
using Restaurant.Domain.Dinner.ValueObjects;
using Restaurant.Domain.GuestAggregate.ValueObjects;
using Restaurant.Domain.Host.ValueObjects;

namespace Restaurant.Domain.BillAggregate;

public sealed class Bill : AggregateRoot<BillId>
{
    public HostId HostId { get; }
    public GuestId GuestId { get; }
    public DinnerId DinnerId { get; }
    public Price Price { get; set; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Bill(
        BillId billId,       
        HostId hostId,
        GuestId guestId,
        DinnerId dinnerId,
        Price price,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(billId)
    {        
        HostId = hostId;
        GuestId = guestId;
        DinnerId = dinnerId;
        Price = price;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Bill Create(        
        HostId hostId,
        GuestId guestId,
        DinnerId dinnerId,
        Price price
        )
    {
        return new(
            BillId.CreateUnique(),           
            hostId,
            guestId,
            dinnerId, 
            price,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

}
