using System;
using System.Collections.Generic;
using Satisfaction.Application.Commands.Acts;

namespace Satisfaction.Application.DTOs
{
    public class ExpertSubmitActRequest
    {
        public int AssignedChassisId { get; set; }
        public bool IsSuccessCall { get; set; }
        public int CustomerStateId { get; set; }
        //baraye neveshtane Unit Test
        public DateTime ActDate { get; set; }
        public DateTime? AlarmDate { get; set; }
        public DateTime? AlarmTime { get; set; }
        public string AlarmDescription { get; set; }
        public int ContactTypeId { get; set; }
        public int Creator { get; set; }

        public List<AnswerItem> AnswerItems { get; set; }
    }
}