using System.Threading.Tasks;
using Satisfaction.Domain.AggregatesModel.Shared;

namespace Satisfaction.Application.Services
{
    public interface ITimeSettingService
    {
        Task<int> GetTimeSettingAsync(int surveyType);
    }
}