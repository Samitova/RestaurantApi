﻿using Restaurant.Domain.Common.Models;

namespace Restaurant.Domain.MenuAggregate.ValueObjects;

public sealed class MenuSectionId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public static MenuSectionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuSectionId Create(Guid value)
    {
        return new MenuSectionId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
