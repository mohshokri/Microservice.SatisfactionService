using System;
using System.Collections.Generic;
using System.Text;
using Satisfaction.Domain.AggregatesModel.Shared;
using Satisfaction.Domain.AggregatesModel.SurveyConfigurationAggregate;

namespace Satisfaction.Application.Queries.Configurations
{
    public class SurveyConfiguration
    {
        public int SurveyType { get; set; }
        public ImpactRate ImpactRate  { get; set; }
        public SamplingMethod SamplingMethod { get; set; }
    }
}
