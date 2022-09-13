

using System;
using System.Collections.Generic;
using MediatR;
using Satisfaction.Domain.Enumerations;

namespace Satisfaction.Application.Commands.Acts
{
    public class ExpertSubmitActCommand : IRequest
    {
        public ExpertSubmitActCommand(int assignedChassisId, bool isSuccessCall, int customerStateId, DateTime actDate, DateTime? alarmDate,
            DateTime? alarmTime, string alarmDescription, int contactTypeId, List<AnswerItem> answerItems, int creator)
        {
            AssignedChassisId = assignedChassisId;
            IsSuccessCall = isSuccessCall;
            CustomerStateId = customerStateId;
            ActDate = actDate;
            AlarmDate = alarmDate;
            AlarmTime = alarmTime;
            AlarmDescription = alarmDescription;
            ContactTypeId = contactTypeId;
            AnswerItems = answerItems;
            Creator = creator;
        }
        public int AssignedChassisId { get; }
        public bool IsSuccessCall { get; }
        public int CustomerStateId { get; }
        //baraye neveshtane Unit Test
        public DateTime ActDate { get; }
        public DateTime? AlarmDate { get; }
        public DateTime? AlarmTime { get; }
        public string AlarmDescription { get; }
        public int ContactTypeId { get; }
        public int Creator { get; }

        public List<AnswerItem> AnswerItems { get; }

    }
}