using System;
using Pluto.EventBus.Abstract;
using Pluto.EventBus.Abstract.Interfaces;

namespace Pluto.EventBus.RabbitMQ
{
    public class EventBusRabbitMQ : IEventBus, IDisposable
    {
        /// <inheritdoc />
        public void Publish(IntegrationEvent @event)
        {
        }

        /// <inheritdoc />
        public void Subscribe<T, TH>() 
            where T : IntegrationEvent 
            where TH : IIntegrationEventHandler<T>
        {
        }

        /// <inheritdoc />
        public void Unsubscribe<T, TH>() 
            where T : IntegrationEvent 
            where TH : IIntegrationEventHandler<T>
        {
        }

        /// <inheritdoc />
        public void SubscribeDynamic<TH>(string eventName) 
            where TH : IDynamicIntegrationEventHandler
        {
        }

        /// <inheritdoc />
        public void UnsubscribeDynamic<TH>(string eventName) 
            where TH : IDynamicIntegrationEventHandler
        {
        }

        /// <inheritdoc />
        public void Dispose()
        {
        }
    }
}