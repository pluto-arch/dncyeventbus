using Pluto.EventBus.Abstract;

namespace Event
{
    public class UserEvent:IntegrationEvent
    {
        public string Code { get; set; }
    }
}