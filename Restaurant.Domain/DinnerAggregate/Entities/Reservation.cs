using Restaurant.Domain.BillAggregate.ValueObjects;
using Restaurant.Domain.Common.Models;
using Restaurant.Domain.DinnerAggregate.ValueObjects;
using Restaurant.Domain.Host.ValueObjects;

namespace Restaurant.Domain.DinnerAggregate.Entities;
public sealed class Reservation : Entity<ReservationId>
{
    public int GuestCount { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
    public HostId HostId { get; }
    public BillId BillId { get; }
    public DateTime ArrivalDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Reservation(
        ReservationId reservationId,
        int guestCount,
        HostId hostId,
        BillId billId,
        DateTime arrivalDateTime,       
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(reservationId)
    {
        GuestCount = guestCount;
        HostId = hostId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;     
    }

    public static Reservation Create(
        int guestCount,
        HostId hostId,
        BillId billId,
        DateTime arrivalDateTime)
    {
        return new(
            ReservationId.CreateUnique(),
            guestCount,
            hostId,
            billId,
            arrivalDateTime,
            DateTime.UtcNow,
            DateTime.UtcNow
            );
    }
}
