using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Satisfaction.Application.Queries.Surveys;

namespace Satisfaction.Application.Services
{
    public interface ISurveyQueryService
    {
        Task<List<SurveyListViewModel>> GetSurveyListQuery();
        Task<SurveyViewModel> GetSelectedSurvey(int surveyId);
    }
}
