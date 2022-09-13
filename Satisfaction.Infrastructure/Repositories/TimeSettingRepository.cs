using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Satisfaction.Domain.AggregatesModel.Shared;
using Satisfaction.Domain.AggregatesModel.TimeSettingAggregate;
using Satisfaction.Infrastructure.Persistence;

namespace Satisfaction.Infrastructure.Repositories
{
    public class TimeSettingRepository:ITimeSettingRepository
    {
        private readonly SatisfactionContext _satisfactionContext;

        public TimeSettingRepository(SatisfactionContext satisfactionContext)
        {
            _satisfactionContext = satisfactionContext;
        }
        public TimeSetting Get(int surveyType)
        {
            return _satisfactionContext.TimeSettings.FirstOrDefault(t => t.Key== surveyType.ToString());
        }
    }
}
