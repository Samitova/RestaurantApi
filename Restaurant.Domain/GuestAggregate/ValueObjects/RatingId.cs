using Restaurant.Domain.Common.Models;
using Restaurant.Domain.Host.ValueObjects;

namespace Restaurant.Domain.GuestAggregate.ValueObjects;

public sealed class RatingId : ValueObject
{
    public Guid Value { get; }
    private RatingId(Guid value)
    {
        Value = value;
    }

    public static RatingId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static RatingId Create(Guid value)
    {
        return new RatingId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}