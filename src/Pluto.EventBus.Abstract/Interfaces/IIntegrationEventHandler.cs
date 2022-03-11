using System.Threading.Tasks;

namespace Pluto.EventBus.Abstract.Interfaces
{
    /// <summary>
    /// 集成事件功能协定
    /// </summary>
    /// <typeparam name="TIntegrationEvent"></typeparam>
    public interface IIntegrationEventHandler<in TIntegrationEvent>
        : IIntegrationEventHandler where TIntegrationEvent : IntegrationEvent
    {
        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        Task Handle(TIntegrationEvent @event);
    }


    public interface IIntegrationEventHandler
    {
    }
}