using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pluto.EventBus.Abstract.Interfaces
{
    public interface IIntegrationEventStore
    {
        Task SaveAsync(string eventName,string eventBody);
        
        Task<IEnumerable<string>> GetListAllAsync();
        
        Task<IEnumerable<string>> GetListAsync(string eventTypeName);
        
        Task<IEnumerable<T>> GetListAsync<T>(string eventTypeName) where T : IntegrationEvent;
        
    }
}