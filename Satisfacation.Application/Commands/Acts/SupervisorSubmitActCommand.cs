using System;
using MediatR;

namespace Satisfaction.Application.Commands.Acts
{
    public class SupervisorSubmitActCommand : IRequest
    {
        public SupervisorSubmitActCommand(int assignedChassisId, bool isSuccessCall, DateTime actDate, DateTime? alarmDate,
            DateTime? alarmTime, string alarmDescription, string crmSupervisorDescription, int contactTypeId, int creator)
        {
            AssignedChassisId = assignedChassisId;
            IsSuccessCall = isSuccessCall;
            ActDate = actDate;
            AlarmDate = alarmDate;
            AlarmTime = alarmTime;
            AlarmDescription = alarmDescription;
            CrmSupervisorDescription = crmSupervisorDescription;
            ContactTypeId = contactTypeId;
            Creator = creator;  
        }
        public int AssignedChassisId { get; }
        public bool IsSuccessCall { get; }
        public DateTime ActDate { get; }
        public DateTime? AlarmDate { get; }
        public DateTime? AlarmTime { get; }
        public string AlarmDescription { get; }
        public string CrmSupervisorDescription { get; }
        public int ContactTypeId { get; }
        public int Creator { get; }
    }
}