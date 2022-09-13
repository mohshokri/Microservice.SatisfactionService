using Satisfaction.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Domain.AggregatesModel.SurveyAggregate.DomainEvents
{
    public class SurveyDeactivated : IDomainEvent
    {
        public DateTime OccurredOn { get; }

        public SurveyDeactivated(DateTime? occurredOn = null)
        {
            OccurredOn = occurredOn ?? DateTime.Now;
        }

    }
}
