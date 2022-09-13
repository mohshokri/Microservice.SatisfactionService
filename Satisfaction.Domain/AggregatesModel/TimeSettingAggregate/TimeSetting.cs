using System;
using System.Collections.Generic;
using System.Text;
using Satisfaction.Domain.SeedWork;

namespace Satisfaction.Domain.AggregatesModel.TimeSettingAggregate
{
    public class TimeSetting:Entity,IAggregateRoot
    {
        public TimeSetting()
        {
                
        }
        public int TimeSettingId { get; set; }
        public string Key { get; set; }
        public int Value { get; set; }
    }
}
