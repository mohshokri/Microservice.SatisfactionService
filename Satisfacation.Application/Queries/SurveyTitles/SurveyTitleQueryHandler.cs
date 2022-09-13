using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using MediatR;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Satisfaction.Application.Services;

namespace Satisfaction.Application.Queries.SurveyTitles
{
    public class SurveyTitleQueryHandler : IRequestHandler<SurveyTitleQuery, List<SurveyTitleInfo>>
    {
        private readonly ISurveyTitleQueryService _surveyTitleQueryService;
        public SurveyTitleQueryHandler(ISurveyTitleQueryService surveyTitleQueryService)
        {
            _surveyTitleQueryService = surveyTitleQueryService;
        }
        public async Task<List<SurveyTitleInfo>> Handle(SurveyTitleQuery request, CancellationToken cancellationToken)
        {
            return await _surveyTitleQueryService.GetSurveyTitleList(request.SurveyType);
        }
    }
}