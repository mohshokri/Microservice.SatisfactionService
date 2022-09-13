using System;

namespace Satisfaction.Application.Queries.CallHistory
{
    public class ContactInfo
    {
        public DateTime ActDate { get; set; }
        public string Name { get; set; }
        public int SurveyType { get; set; }
        public bool IsSuccessCall { get; set; }
        public string ChassisNumber { get; set; }

    }
}