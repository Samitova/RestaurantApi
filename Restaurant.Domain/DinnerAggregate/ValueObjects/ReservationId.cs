﻿using Restaurant.Domain.Common.Models;

namespace Restaurant.Domain.DinnerAggregate.ValueObjects;
public sealed class ReservationId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private ReservationId(Guid value)
    {
        Value = value;
    }

    public static ReservationId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static ReservationId Create(Guid value)
    {
        return new ReservationId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}