using System.Linq;
using System.Threading.Tasks;
using Satisfaction.Application.Services;
using Satisfaction.Domain.AggregatesModel.Shared;
using Satisfaction.Domain.AggregatesModel.TimeSettingAggregate;
using Satisfaction.Infrastructure.Persistence;

namespace Satisfaction.Infrastructure.Services
{
    public class TimeSettingService: ITimeSettingService
    {
        private readonly SatisfactionContext _satisfactionContext;

        public TimeSettingService(SatisfactionContext satisfactionContext)
        {
            _satisfactionContext = satisfactionContext;
        }

        public async Task<int> GetTimeSettingAsync(int surveyType)
        {
            return _satisfactionContext.TimeSettings.FirstOrDefault(t => t.Key == surveyType.ToString()).Value;
        }
    }
}