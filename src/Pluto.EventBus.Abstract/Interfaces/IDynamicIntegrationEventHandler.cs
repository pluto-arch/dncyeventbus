using System.Threading.Tasks;

namespace Pluto.EventBus.Abstract.Interfaces
{
    /// <summary>
    /// 动态事件处理协定
    /// </summary>
    public interface IDynamicIntegrationEventHandler
    {
        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="eventData"></param>
        /// <returns></returns>
        Task Handle(dynamic eventData);
    }
}