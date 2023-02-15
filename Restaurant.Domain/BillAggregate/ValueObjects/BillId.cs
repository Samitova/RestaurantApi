﻿using Restaurant.Domain.Common.Models;

namespace Restaurant.Domain.BillAggregate.ValueObjects;

public sealed class BillId : ValueObject
{
    public Guid Value { get; }
    private BillId(Guid value)
    {
        Value = value;
    }

    public static BillId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static BillId Create(Guid value)
    {
        return new BillId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}