using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Satisfaction.Domain.AggregatesModel.Shared;
using Satisfaction.Domain.SeedWork;

namespace Satisfaction.Domain.AggregatesModel.SurveyConfigurationAggregate
{
    public interface ISurveyConfigurationRepository:IRepository<SurveyConfiguration>
    {
        Task<SurveyConfiguration> GetAsync(int SurveyConfigurationId);
        List<SurveyConfiguration> GetSurveyConfigurationList(int surveyType);


    }
}
