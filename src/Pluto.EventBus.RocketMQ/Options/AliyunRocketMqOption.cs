using System.ComponentModel;
using System;

namespace Pluto.EventBus.AliyunRocketMQ
{
    /// <summary>
    /// 阿里云rocketmq选项设置
    /// </summary>
    public class AliyunRocketMqOption
    {

        public AliyunRocketMqOption(string instranceId,string topic,string groupId,uint bitchSize=1,uint waitSecond=3)
        {
            InstranceId = string.IsNullOrEmpty(instranceId)? throw new InvalidOperationException(nameof(InstranceId)):instranceId;
            Topic = string.IsNullOrEmpty(topic)? throw new InvalidOperationException(nameof(Topic)) : topic;
            GroupId = string.IsNullOrEmpty(topic)? throw new InvalidOperationException(nameof(GroupId)):groupId;
            BitchSize= bitchSize<=0 ? throw new InvalidOperationException(nameof(BitchSize)): bitchSize;
            WaitSecond = waitSecond;
        }


        /// <summary>主题</summary>
        [Description("主题")]
        public string Topic { get; set; }

        /// <summary>实例id</summary>
        [Description("实例id")]
        public string InstranceId { get; set; }

        /// <summary>消费组</summary>
        [Description("消费组Id")]
        public string GroupId { get; set; }

        /// <summary>单次消费的数量(最低1)</summary>
        [Description("单次消费的数量(最低1)")]
        public uint BitchSize { get; set; }

        /// <summary>长连接时间(1-30)s</summary>
        [Description("长连接时间(1-30)s")]
        public uint WaitSecond { get; set; }

    }
}