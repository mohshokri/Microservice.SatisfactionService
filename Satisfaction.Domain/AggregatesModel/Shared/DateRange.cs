using Dawn;
using Satisfaction.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Domain.AggregatesModel.Shared
{
    public class DateRange : ValueObject
    {
        private DateRange()
        {

        }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public DateRange(DateTime startDate, DateTime endDate)
        {
            Guard.Argument(startDate, nameof(startDate)).Require(s => s < endDate);
            StartDate = startDate;
            EndDate = endDate;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
