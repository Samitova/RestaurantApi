using Restaurant.Domain.Common.Models;
using Restaurant.Domain.Dinner.ValueObjects;

namespace Restaurant.Domain.DinnerAggregate.ValueObjects;
public sealed class LocationId : ValueObject
{
    public Guid Value { get; }
    private LocationId(Guid value)
    {
        Value = value;
    }

    public static LocationId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static LocationId Create(Guid value)
    {
        return new LocationId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}