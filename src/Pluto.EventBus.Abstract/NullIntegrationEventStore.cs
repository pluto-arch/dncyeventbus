using System.Collections.Generic;
using System.Threading.Tasks;
using Pluto.EventBus.Abstract.Interfaces;

namespace Pluto.EventBus.Abstract
{
    public class NullIntegrationEventStore:IIntegrationEventStore
    {
        /// <inheritdoc />
        public async Task SaveAsync(string eventName, string eventBody)
        {
            await Task.CompletedTask;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<string>> GetListAllAsync()
        {
            await Task.CompletedTask;
            return default;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<string>> GetListAsync(string eventTypeName)
        {
            await Task.CompletedTask;
            return default;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> GetListAsync<T>(string eventTypeName) where T : IntegrationEvent
        {
            await Task.CompletedTask;
            return default;
        }

        public static IIntegrationEventStore Instance { get; set; }=new NullIntegrationEventStore();
    }
}