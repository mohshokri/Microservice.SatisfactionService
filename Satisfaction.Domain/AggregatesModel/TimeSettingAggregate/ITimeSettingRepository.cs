using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Satisfaction.Domain.AggregatesModel.Shared;
using Satisfaction.Domain.SeedWork;

namespace Satisfaction.Domain.AggregatesModel.TimeSettingAggregate
{
   public interface ITimeSettingRepository: IRepository<TimeSetting>
    {
        public TimeSetting Get(int surveyType);
    }
}
