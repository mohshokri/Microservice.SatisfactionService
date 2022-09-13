using System.Collections.Generic;
using System.Threading.Tasks;
using Satisfaction.Application.Queries.SurveyTitles;

namespace Satisfaction.Application.Services
{
    public interface ISurveyTitleQueryService
    {
        Task<List<SurveyTitleInfo>> GetSurveyTitleList(int surveyType);
    }
}