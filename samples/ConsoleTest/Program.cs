using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Pluto.EventBus.AliyunRocketMQ;
using Aliyun.MQ;
using Event;
using Newtonsoft.Json;
using Pluto.EventBus.Abstract;
using Pluto.EventBus.Abstract.Interfaces;

namespace EventBusRocketMqConsoleTest
{

    public class NewtonsoftMessageSerializeProvider : IMessageSerializeProvider
    {
        /// <inheritdoc />
        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <inheritdoc />
        public T Deserialize<T>(string objStr)
        {
            return JsonConvert.DeserializeObject<T>(objStr);
        }

        /// <inheritdoc />
        public object Deserialize(string objStr, Type type)
        {
            return JsonConvert.DeserializeObject(objStr,type);
        }
    }

    internal class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();


            services.AddMqClient("key", "secret", "httpendpoint");
            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
            services.AddTransient<IMessageSerializeProvider, NewtonsoftMessageSerializeProvider>();
            services.AddSingleton<IEventBus, EventBusRocketMQ>(sp =>
            {
                var mqClient = sp.GetRequiredService<MQClient>();
                var subMgr = sp.GetRequiredService<IEventBusSubscriptionsManager>();
                var serviceFactory = sp.GetRequiredService<IServiceScopeFactory>();
                var serializeProvider = sp.GetRequiredService<IMessageSerializeProvider>();
                return new EventBusRocketMQ(mqClient, subMgr, serviceFactory, new AliyunRocketMqOption("instranceid", "topic", "groupid"), serializeProvider);
            });

            var provicder = services.BuildServiceProvider();
            var p = provicder.GetRequiredService<IEventBus>();
           

            string i = "";
            do
            {
                i = Console.ReadLine();
                p.Publish(new DemoEvent
                {
                    Name = i+ "_DemoEvent"
                });
                await Task.Delay(1000);
                i = Console.ReadLine();
                p.Publish(new UserEvent
                {
                    Code = i + "_UserEvent"
                });


            } while (i!="exit");
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }

}
