using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Satisfaction.Domain.AggregatesModel.SurveyAssignmentAggregate;
using Satisfaction.Infrastructure.Persistence;

namespace Satisfaction.Infrastructure.Repositories
{
    public class SurveyAssignmentRepository:ISurveyAssignmentRepository
    {
        private readonly SatisfactionContext _context;

        public SurveyAssignmentRepository(SatisfactionContext context)
        {
            _context = context;
        }
        public async Task AddAsync(SurveyAssignment surveyAssignment)
        {
            await _context.SurveyAssignments.AddAsync(surveyAssignment);
        }
    }
}
