using Microsoft.EntityFrameworkCore;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate;
using Satisfaction.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Satisfaction.Infrastructure.Repositories
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly SatisfactionContext _satisfactionContext;

        public SurveyRepository(SatisfactionContext satisfactionContext)
        {
            _satisfactionContext = satisfactionContext;
        }

        public async Task Add(Survey survey)
        {
           await _satisfactionContext.Surveys.AddAsync(survey);
           
        }

        public Task<Survey> GetAsync(int surveyId)
        {
            return _satisfactionContext.Surveys.Include(c => c.Questions).ThenInclude(t => t.QuestionItems).FirstOrDefaultAsync(s => s.SurveyId == surveyId);
        }

        public Task Update(Survey survey)
        {
            return Task.CompletedTask;
        }
    }
}
