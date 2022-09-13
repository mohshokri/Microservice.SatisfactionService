using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Satisfaction.Domain.AggregatesModel.SurveyConfigurationAggregate;
using Satisfaction.Infrastructure.Persistence;

namespace Satisfaction.Infrastructure.Repositories
{
    public class SurveyConfigurationRepository: ISurveyConfigurationRepository
    {
        private readonly SatisfactionContext _satisfactionContext;

        public SurveyConfigurationRepository(SatisfactionContext satisfactionContext)
        {
            _satisfactionContext = satisfactionContext;
        }
        public Task<SurveyConfiguration> GetAsync(int surveyConfigurationId)
        {
            return   _satisfactionContext.SurveyConfigurations.FirstOrDefaultAsync(t =>
                t.SurveyConfigurationId == surveyConfigurationId);
        }

        public List<SurveyConfiguration> GetSurveyConfigurationList(int surveyType)
        {
            return  _satisfactionContext.SurveyConfigurations.Where(t => t.SurveyType == surveyType).ToList();
        }
    }
}
