using System;

namespace Satisfaction.Application.Commands.SurveyAssignments
{
    public class ChassisInfoFromErp
    {
        public string NAME { get; set; }
        public string ChassisNo { get; set; }
        public int DATEDIFF { get; set; }
        public DateTime EXIT_DATE { get; set; }
        public string DRIVERNAME { get; set; }
        public string DRIVER_TEL { get; set; }
        public DateTime REFERRAL_DATE { get; set; }
        public string DESCRIPTION { get; set; }
        public string type { get; set; }

    }
}