using Satisfaction.Domain.AggregatesModel.SurveyAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using Satisfaction.Domain.AggregatesModel.Shared;

namespace Satisfaction.Application.Queries.Surveys
{
    public class SurveyListViewModel
    {
        public int SurveyId { get; set; }
        public string SurveyCode { get; set; }
        public SurveyType SurveyType { get; set; }
        public string SurveyTitle { get; set; }
        public bool IsAnswered { get; set; }
    }
}
