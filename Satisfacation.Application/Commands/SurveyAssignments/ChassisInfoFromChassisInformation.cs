using System;

namespace Satisfaction.Application.Commands.SurveyAssignments
{
    public class ChassisInfoFromChassisInformation
    {
        public string ChassisNo { get; set; }
        public int DATEDIFF { get; set; }
        public DateTime ExitDate { get; set; }
        public string modeel { get; set; }
        public string type { get; set; }
        public string type_id { get; set; }
        public string OwnerName { get; set; }
        public int warrany { get; set; }

    }
}