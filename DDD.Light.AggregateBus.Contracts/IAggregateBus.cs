﻿using DDD.Light.AggregateCache.Contracts;
using DDD.Light.CQRS.Contracts;

namespace DDD.Light.AggregateBus.Contracts
{
    public interface IAggregateBus
    {
        void Configure(IEventBus eventBus, IAggregateCache aggregateCache);
        void Publish<TAggregate, TId, TEvent>(TId aggregateId, TEvent @event) where TAggregate : IAggregateRoot<TId>;
    }
}