using Satisfaction.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Domain.AggregatesModel.SurveyAggregate.DomainEvents
{
    public class SurveyActivated : IDomainEvent
    {
        public string SurveyCode { get; }
        public DateTime OccurredOn { get; }

        public SurveyActivated(string surveyCode, DateTime? occurredOn=null)
        {
            OccurredOn = occurredOn ?? DateTime.Now;
            SurveyCode = surveyCode;
        }
    }
}
