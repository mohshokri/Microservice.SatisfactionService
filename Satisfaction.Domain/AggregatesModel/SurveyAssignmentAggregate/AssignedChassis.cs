using Satisfaction.Domain.AggregatesModel.ActAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using Satisfaction.Domain.SeedWork;

namespace Satisfaction.Domain.AggregatesModel.SurveyAssignmentAggregate
{
    public class AssignedChassis:Entity
    {
        public AssignedChassis()
        {
                
        }
        public int AssignedChassisId { get; set; }
        public int SurveyAssignmentId { get; set; }
        public string ChassisNumber { get; set; }

        public SurveyAssignment SurveyAssignment { get; set; }
        public List<Act> Acts { get; set; }
    }
}
