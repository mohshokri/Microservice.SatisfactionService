using Satisfaction.Domain.AggregatesModel.PartyAggregate;
using Satisfaction.Domain.AggregatesModel.SurveyConfigurationAggregate;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using Satisfaction.Domain.SeedWork;

namespace Satisfaction.Domain.AggregatesModel.SurveyAssignmentAggregate
{
    public class SurveyAssignment : Entity, IAggregateRoot
    {
        public SurveyAssignment()
        {
            // _assignedChassis = new List<AssignedChassis>();
        }
        public SurveyAssignment(int partyId, int franchiseId, ProductType productType, DateTime endDate, int surveyConfigurationId, List<AssignedChassis> assignChassis)
        {
            PartyId = partyId;
            ProductType = productType;
            //_assignedChassis = new List<AssignedChassis>();
            EndDate = endDate;
            SurveyConfigurationId = surveyConfigurationId;
            AssignedChassis = assignChassis;
            FranchiseId = franchiseId;
        }
        public int SurveyAssignmentId { get; set; }
        public int SurveyConfigurationId { get; set; }
        public int PartyId { get; set; }
        public int FranchiseId { get; }
        public ProductType ProductType { get; set; }
        public DateTime EndDate { get; set; }
        public List<AssignedChassis> AssignedChassis { get; set; }

        //private readonly List<AssignedChassis> _assignedChassis;
        //public IReadOnlyCollection<AssignedChassis> AssignedChassis => _assignedChassis;
        public Party Party { get; set; }

    }
}
