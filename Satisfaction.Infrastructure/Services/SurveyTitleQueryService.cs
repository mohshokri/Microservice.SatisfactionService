using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Satisfaction.Application.Queries.SurveyTitles;
using Satisfaction.Application.Services;
using Satisfaction.Domain.AggregatesModel.Shared;
using Satisfaction.Infrastructure.Persistence;

namespace Satisfaction.Infrastructure.Services
{
    public class SurveyTitleQueryService : ISurveyTitleQueryService
    {
        private readonly SatisfactionContext _context;

        public SurveyTitleQueryService(SatisfactionContext context)
        {
            _context = context;
        }

        public Task<List<SurveyTitleInfo>> GetSurveyTitleList(int surveyType)
        {
            return _context.Surveys.Where(t => t.SurveyType == surveyType)
                .Select(t => new SurveyTitleInfo() { SurveyId = t.SurveyId, SurveyTitle = t.SurveyTitle }).AsNoTracking().ToListAsync();
        }
    }
}