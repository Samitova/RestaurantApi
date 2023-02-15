using Restaurant.Domain.Common.Models;
using Restaurant.Domain.Dinner.ValueObjects;
using Restaurant.Domain.GuestAggregate.ValueObjects;
using Restaurant.Domain.Host.ValueObjects;
using Restaurant.Domain.Menu.ValueObjects;
using Restaurant.Domain.MenuReview.ValueObjects;

namespace Restaurant.Domain.MenuReviewAggregate;
public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    public int RatingValue { get; private set; }
    public string Comment { get; set; }
    public HostId HostId { get; private set; }
    public GuestId GuestId { get; private set; }    
    public DinnerId DinnerId { get; private set; }
    public MenuId MenuId { get; private set; }   
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private MenuReview(
        MenuReviewId menuReviewId,
        int ratingValue,
        string comment,        
        HostId hostId,
        GuestId guestId,
        DinnerId dinnerId,
        MenuId menuId,        
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(menuReviewId)
    {
        RatingValue = ratingValue;
        Comment = comment;
        HostId = hostId;
        GuestId = guestId;
        DinnerId = dinnerId;
        MenuId = menuId;        
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    public static MenuReview Create(
        int ratingValue,
        string comment,
        HostId hostId,
        GuestId guestId,
        DinnerId dinnerId,
        MenuId menuId
        )
    {
        return new(
            MenuReviewId.CreateUnique(),
            ratingValue,
            comment,
            hostId,
            guestId,
            dinnerId,
            menuId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}