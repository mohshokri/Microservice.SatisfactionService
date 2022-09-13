using System;

namespace Satisfaction.Application.DTOs
{
    public class SupervisorSubmitActRequest
    {
        public int AssignedChassisId { get; set; }
        public bool IsSuccessCall { get; set; }
        public DateTime ActDate { get; set; }
        public DateTime? AlarmDate { get; set; }
        public DateTime? AlarmTime { get; set; }
        public string AlarmDescription { get; set; }
        public string CrmSupervisorDescription { get; set; }
        public int ContactTypeId { get; set; }
        public int Creator { get; set; }
    }
}