using Restaurant.Domain.Common.Models;
using Restaurant.Domain.UserAggregate.ValueObjects;

namespace Restaurant.Domain.Host.ValueObjects;

public sealed class HostId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private HostId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static HostId Create(Guid value)
    {
        return new HostId(value);
    }

    public static HostId Create(string value)
    {
        if (!Guid.TryParse(value, out var id))
            throw new ArgumentException(nameof(value));
        return new HostId(id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}