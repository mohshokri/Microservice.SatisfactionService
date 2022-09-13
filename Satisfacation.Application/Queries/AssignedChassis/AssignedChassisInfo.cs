using System;
using Satisfaction.Domain.AggregatesModel.Shared;

namespace Satisfaction.Application.Queries.AssignedChassis
{
    public class AssignedChassisInfo
    {
        public int PartyId { get; set; }
        public int SurveyType { get; set; }
        public DateTime EndDate { get; set; }
        public int AssignedChassisCount { get; set; }
        public int AnsweredCount { get; set; }
        //Mohasebati
        public int RemainAssignedChassisCount { get; set; }



        public string SurveyTitle => Domain.AggregatesModel.Shared.SurveyType.FromValue(SurveyType).Name;
    }
}