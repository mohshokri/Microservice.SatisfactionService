using System.Collections.Generic;
using MediatR;
using Satisfaction.Domain.AggregatesModel.Shared;

namespace Satisfaction.Application.Queries.SurveyTitles
{
    public class SurveyTitleQuery : IRequest<List<SurveyTitleInfo>>
    {
        public int SurveyType { get; set; }
    }
}