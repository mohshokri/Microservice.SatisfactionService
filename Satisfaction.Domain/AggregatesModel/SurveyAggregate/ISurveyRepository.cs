using Satisfaction.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Satisfaction.Domain.AggregatesModel.SurveyAggregate
{
    public interface ISurveyRepository:IRepository<Survey>
    {
        Task Add(Survey survey);
        Task Update(Survey survey);
        Task<Survey> GetAsync(int surveyId);
    }
}
