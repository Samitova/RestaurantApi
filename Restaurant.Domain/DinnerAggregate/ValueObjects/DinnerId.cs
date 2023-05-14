using Restaurant.Domain.Common.Models;

namespace Restaurant.Domain.Dinner.ValueObjects;
public sealed class DinnerId : AggregateRootId<Guid>
{ 
    public override Guid Value { get; protected set; }    
    private DinnerId(Guid value)
    {
        Value = value;
    }

    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static DinnerId Create(Guid value)
    {
        return new DinnerId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}