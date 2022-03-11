using System;
using Pluto.EventBus.Abstract;

namespace Event
{
    public class DemoEvent:IntegrationEvent
    {

        public string Name { get; set; }

    }
}
