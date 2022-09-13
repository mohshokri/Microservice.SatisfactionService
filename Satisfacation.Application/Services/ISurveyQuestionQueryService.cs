using System.Collections.Generic;
using System.Threading.Tasks;
using Satisfaction.Application.Queries.SurveyQuestions;

namespace Satisfaction.Application.Services
{
    public interface ISurveyQuestionQueryService
    {
        Task<List<QuestionInfo>> GetQuestionListQuery(int surveyId);
    }
}