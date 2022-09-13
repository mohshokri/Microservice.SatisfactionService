using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Satisfaction.Domain.AggregatesModel.Shared;

namespace Satisfaction.Application.Queries.Configurations
{
    public class GetSurveyConfigurationQuery : IRequest<SurveyConfigurationList>
    {
        public int SurveyType { get; set; }
    }
}
