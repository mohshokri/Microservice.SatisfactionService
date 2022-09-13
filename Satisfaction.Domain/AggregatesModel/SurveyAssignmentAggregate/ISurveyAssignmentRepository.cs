using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Satisfaction.Domain.SeedWork;

namespace Satisfaction.Domain.AggregatesModel.SurveyAssignmentAggregate
{
    public interface ISurveyAssignmentRepository:IRepository<SurveyAssignment>
    {
        Task AddAsync(SurveyAssignment surveyAssignment);
    }
}
