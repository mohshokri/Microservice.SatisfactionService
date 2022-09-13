using System;
using Satisfaction.Domain.AggregatesModel.SurveyAssignmentAggregate;

namespace Satisfaction.Application.DTOs
{
    public class AssignChassisRequest
    {

        public int FranchiseId { get; set; }
        public int PartyId { get; set; }
        // public int ChassisIncluded { get; }
        public int AssignedChassisCount { get; set; }
        public int ProductType { get; set; }
        public DateTime EndDate { get; set; }
        public int SurveyConfigurationId { get; set; }
    }
}