# pluto_eventbus

### 使用方式
```
services.AddMqClient("accesskey", "secret", "httphost");
services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
services.AddSingleton<DemoHandler>();
services.AddTransient<IMessageSerializeProvider, NewtonsoftMessageSerializeProvider>();
services.AddSingleton<IEventBus, EventBusRocketMQ>(sp =>
{
    var logger = sp.GetRequiredService<ILogger<EventBusRocketMQ>>();
    var mqClient = sp.GetRequiredService<MQClient>();
    var subMgr = sp.GetRequiredService<IEventBusSubscriptionsManager>();
    var serviceFactory = sp.GetRequiredService<IServiceScopeFactory>();
    var serializeProvider = sp.GetRequiredService<IMessageSerializeProvider>();
    return new EventBusRocketMQ(mqClient, subMgr, serviceFactory, new AliyunRocketMqOption("instranceid", "topicid", "groupid"), serializeProvider, logger);
});
```


## 事件处理程序示例：
```
public class DemoHandler : IIntegrationEventHandler<DemoEvent>
    {
        private readonly ILogger<DemoHandler> _logger;

        public DemoHandler(ILogger<DemoHandler> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc />
        public async Task Handle(DemoEvent @event)
        {
            if (@event == null)
            {
                _logger.LogWarning("【DemoHandler】接收到 DemoEvent。 数据为空");
            }

            _logger.LogInformation("【DemoHandler】接收到 DemoEvent 。 数据：{@event}",JsonSerializer.Serialize(@event));
            await Task.Delay(2000);
        }
    }
```