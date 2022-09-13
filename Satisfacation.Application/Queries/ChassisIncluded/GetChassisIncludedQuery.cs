using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Satisfaction.Domain.AggregatesModel.Shared;

namespace Satisfaction.Application.Queries.ChassisIncluded
{
    public class GetChassisIncludedQuery:IRequest<int>
    {
        public int SurveyType { get; set; }
    }
}
