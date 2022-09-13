using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate;
using Satisfaction.Infrastructure.Persistence;

namespace Satisfaction.Infrastructure.Repositories
{
    public class SurveyQuestionRepository : ISurveyQuestionRepository
    {
        private readonly SatisfactionContext _context;
        public async Task<SurveyQuestion> GetAsync(int surveyId)
        {
            return await _context.Questions.Include(c => c.QuestionItems).FirstOrDefaultAsync(s => s.SurveyId == surveyId);

        }
    }
}