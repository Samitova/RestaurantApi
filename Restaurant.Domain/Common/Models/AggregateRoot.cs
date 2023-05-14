namespace Restaurant.Domain.Common.Models;
public class AggregateRoot<TId, TIdType>: Entity<TId>
    where TId : notnull
{
    public new AggregateRootId<TIdType> Id { get; protected set; }
    protected AggregateRoot(TId id): base(id)
	{
	}

    protected AggregateRoot() 
    {
    }
}
