using Dawn;
using Satisfaction.Domain.AggregatesModel.ActAggregate;
using Satisfaction.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Satisfaction.Domain.AggregatesModel.SurveyAggregate
{
    public class SurveyAnswer : Entity
    {
        private SurveyAnswer()
        {

        }
        public SurveyAnswer(int assignedChassisId, List<AnswerQuestionItem> answerQuestionItems)
        {
            Guard.Argument(assignedChassisId).Positive();
            AssignedChassisId = assignedChassisId;
            AnswerQuestionItems = answerQuestionItems;
        }
        public int AnswerId { get; private set; }
        //public int QuestionItemId { get; private set; }
        public int AssignedChassisId { get; private set; }
        public DateTime Date { get; set; }
        public List<AnswerQuestionItem> AnswerQuestionItems { get; set; }

        //public Survey Survey { get; set; }
         //public Act Act { get; private set; }

        //public void SetQuestionItemId(int questionItemId)
        //{
        //    Guard.Argument(questionItemId).Positive();
        //    QuestionItemId = questionItemId;
        //}
        public void SetAssignedChassisId(int assignedChassisId)
        {
            Guard.Argument(assignedChassisId).NotNegative().NotZero();
            AssignedChassisId = assignedChassisId;
        }

        // public void SetAct(Act act) => Act = act;

    }
}
