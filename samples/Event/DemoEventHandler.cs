using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Pluto.EventBus.Abstract.Interfaces;

namespace Event
{
    public class DemoEventHandler:IIntegrationEventHandler<DemoEvent>
    {
        private readonly ILogger<DemoEventHandler> _logger;
        public DemoEventHandler(ILogger<DemoEventHandler> logger)
        {
            _logger = logger;
        }



        /// <inheritdoc />
        public async Task Handle(DemoEvent @event)
        {
            await Task.Yield();

            _logger.LogInformation($"[DemoEventHandler] : {@event.Name}");
        }
    }
}