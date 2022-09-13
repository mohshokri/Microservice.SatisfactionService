using System.Threading.Tasks;

namespace Satisfaction.Domain.AggregatesModel.SurveyAggregate
{
    public interface ISurveyQuestionRepository
    {
        Task<SurveyQuestion> GetAsync(int surveyId);
    }
}