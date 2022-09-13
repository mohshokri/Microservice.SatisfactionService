using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Satisfaction.Application.Queries.ChassisIncluded;
using Satisfaction.Domain.AggregatesModel.Shared;
using Satisfaction.Domain.AggregatesModel.SurveyAssignmentAggregate;

namespace Satisfaction.Application.Services
{
    public interface IChassisQueryService
    {
        Task<int> GetChassisIncludedCountAsync(SurveyType surveyType);
        Task<IEnumerable<ChassisInfo>> GetChassisIncludedListFromErpAsync(int timeSettingValue, ProductType productType, int assignedChassisCount);
        Task<IEnumerable<ChassisInfo>> GetChassisIncludedListFromChassisInformationAsync(int timeSettingValue, ProductType productType, int assignedChassisCount);

    }
}