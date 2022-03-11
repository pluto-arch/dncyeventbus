﻿using System;

namespace Pluto.EventBus.Abstract
{
    /// <summary>
    /// 集成事件
    /// </summary>
    public class IntegrationEvent
    {
        public IntegrationEvent()
        {
            Id = $"{Guid.NewGuid():N}";
            CreationDate = DateTime.UtcNow;
            DelaySecond = 0;
        }


        public IntegrationEvent(string id, DateTime createDate)
        {
            Id = id;
            CreationDate = createDate;
            DelaySecond = 0;
        }

        public string Id { get; set; }

        public DateTime CreationDate { get; set; }

        /// <summary>
        /// 延迟时间
        /// </summary>
        public int DelaySecond { get; set; }
    }
}