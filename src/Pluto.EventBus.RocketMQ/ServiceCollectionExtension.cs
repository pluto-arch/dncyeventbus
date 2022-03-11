using Aliyun.MQ;
using Microsoft.Extensions.DependencyInjection;

namespace Pluto.EventBus.AliyunRocketMQ
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMqClient(this IServiceCollection service,string accessKey,string accessSecret,string endPoint)
        {
            service.AddSingleton<MQClient>(x=>new MQClient(accessKey, accessSecret, endPoint));
            return service;
        }
    }
}