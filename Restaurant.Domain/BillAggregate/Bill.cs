using Restaurant.Domain.BillAggregate.ValueObjects;
using Restaurant.Domain.Common.Entities;
using Restaurant.Domain.Common.Models;
using Restaurant.Domain.Dinner.ValueObjects;
using Restaurant.Domain.GuestAggregate.ValueObjects;
using Restaurant.Domain.Host.ValueObjects;

namespace Restaurant.Domain.BillAggregate;

public sealed class Bill : AggregateRoot<BillId, Guid>
{
    public HostId HostId { get; private set; }
    public GuestId GuestId { get; private set; }
    public DinnerId DinnerId { get; private set; }
    public Price Price { get; set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

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

    protected Bill()
    { }
}
