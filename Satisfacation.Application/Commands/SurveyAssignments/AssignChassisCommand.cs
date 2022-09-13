using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Satisfaction.Domain.AggregatesModel.SurveyAssignmentAggregate;

namespace Satisfaction.Application.Commands.SurveyAssignments
{
    public class AssignChassisCommand : IRequest
    {
        public AssignChassisCommand(int franchiseId, int partyId, int assignedChassisCount, ProductType productType
            , DateTime endDate,int surveyConfigurationId)
        {
            FranchiseId = franchiseId;
            PartyId = partyId;
           // ChassisIncluded = chassisIncluded;
            AssignedChassisCount = assignedChassisCount;
            ProductType = productType;
            EndDate = endDate;
            SurveyConfigurationId = surveyConfigurationId;
        }
        public int FranchiseId { get; }
        public int PartyId { get; }
       // public int ChassisIncluded { get; }
        public int AssignedChassisCount { get; }
        public ProductType ProductType { get; }
        public DateTime EndDate { get; }
        public int SurveyConfigurationId { get; set; }
    }
}
