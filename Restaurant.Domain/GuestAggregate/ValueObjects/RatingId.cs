using Restaurant.Domain.Common.Models;

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

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}