using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Restaurant.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Persistence.Interceptors
{
    public class PublishDomainEventsInterseptor: SaveChangesInterceptor
    {
        private readonly IPublisher _mediator;

        public PublishDomainEventsInterseptor(IPublisher mediator)
        {
            _mediator = mediator;
        }
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            PublishDomainEvents(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }
        public async override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            await PublishDomainEvents(eventData.Context);
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public async Task PublishDomainEvents(DbContext? dbContext)
        {
            if (dbContext is null)
            {
                return;
            }

            // get hold of all various entities
            var entitiesWithDomainEvents = dbContext.ChangeTracker.Entries<IHasDomainEvents>()
                .Where(entity => entity.Entity.DomainEvents.Any())
                .Select(entity => entity.Entity)
                .ToList();

            // get hold of all the various domain events
            var domainEvents = entitiesWithDomainEvents.SelectMany(entity => entity.DomainEvents).ToList();

            // clear domain events
            entitiesWithDomainEvents.ForEach(entity => entity.ClearDomainEvents());

            // publish domain events
            foreach (var domainEvent in domainEvents)
            { 
                await _mediator.Publish(domainEvent);
            }           
        }
    }
}
