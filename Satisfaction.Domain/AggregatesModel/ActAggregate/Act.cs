using Satisfaction.Domain.AggregatesModel.SurveyAggregate;
using Satisfaction.Domain.AggregatesModel.SurveyAssignmentAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using Satisfaction.Domain.SeedWork;
using static Satisfaction.Domain.Enumerations.Enumeration;

namespace Satisfaction.Domain.AggregatesModel.ActAggregate
{
    public class Act : Entity, IAggregateRoot
    {
        public Act()
        {
            
        }

        public Act(int assignedChassisId, bool isSuccessCall, DateTime actDate, DateTime? alarmDate,
            DateTime? alarmTime, string alarmDescription, string crmSupervisorDescription, ContactType contactType, int creator)
        {
            AssignedChassisId = assignedChassisId;
            IsSuccessCall = isSuccessCall;
            ActDate = actDate;
            AlarmDate = alarmDate;
            AlarmTime = alarmTime;
            AlarmDescription = alarmDescription;
            CrmSupervisorDescription = crmSupervisorDescription;
            ContactType = contactType;
            Creator = creator;
            CustomerState = CustomerState.Dissatisfied;
            SurveyAnswer = null;
        }
        public Act(int assignedChassisId, bool isSuccessCall, bool isSurvey, int? answerId, CustomerState customerState, DateTime actDate,
            DateTime? alarmDate, DateTime? alarmTime, string alarmDescription, ContactType contactType,
            string crmSupervisorDescription, int creator, DateTime creationDate, int assignedChassis, SurveyAnswer surveyAnswer)
        {
            AssignedChassisId = assignedChassisId;
            IsSuccessCall = isSuccessCall;
            IsSurvey = isSurvey;
            AnswerId = answerId;
            CustomerState = customerState;
            ActDate = actDate;
            AlarmDate = alarmDate;
            AlarmTime = alarmTime;
            AlarmDescription = alarmDescription;
            ContactType = contactType;
            CrmSupervisorDescription = crmSupervisorDescription;
            Creator = creator;
            CreationDate = creationDate;
            AssignedChassisId = assignedChassis;
            SurveyAnswer = surveyAnswer;
        }
        public int ActId { get; set; }
        public int AssignedChassisId { get; set; }
        public bool IsSuccessCall { get; set; }
        public bool IsSurvey { get; set; }
        public int? AnswerId { get; set; }
        public CustomerState CustomerState { get; set; }
        //زمان تماس
        public DateTime ActDate { get; set; }
        //تاریخ هشدار
        public DateTime? AlarmDate { get; set; }
        //زمان هشدار
        public DateTime? AlarmTime { get; set; }
        public string AlarmDescription { get; set; }
        public ContactType ContactType { get; set; }
        //توضیحات صفحه نظرسنجی مشتریان ناراضی
        public string CrmSupervisorDescription { get; set; }
        public int Creator { get; set; }
        public DateTime CreationDate { get; set; }
        public AssignedChassis AssignedChassis { get; set; }
        public SurveyAnswer? SurveyAnswer { get; set; }
        // public List<SurveyAnswer> SurveyAnswers { get; set; }



    }
}
