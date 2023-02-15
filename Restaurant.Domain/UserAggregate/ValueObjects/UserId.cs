using Restaurant.Domain.Common.Models;
using Restaurant.Domain.MenuReview.ValueObjects;

namespace Restaurant.Domain.UserAggregate.ValueObjects;

public sealed class UserId: ValueObject
{
    public Guid Value { get; }
    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static UserId Create(Guid value)
    {
        return new UserId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
