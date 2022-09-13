using Dawn;
using Satisfaction.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Domain.AggregatesModel.SurveyAggregate
{
    public class SurveyQuestionItem : Entity
    {
        private SurveyQuestionItem()
        {

        }
        public SurveyQuestionItem(string questionItemTitle)
        {
            Guard.Argument(questionItemTitle).NotNull().NotWhiteSpace();

            Guard.Argument(questionItemTitle).MaxLength(300);
            QuestionId = QuestionId;
            QuestionItemTitle = questionItemTitle;
        
            //Description = description;
        }
        public SurveyQuestionItem(string questionItemTitle, int value)
        {
            QuestionItemTitle = questionItemTitle;
            QuestionItemValue = value;

        }
        public int QuestionItemId { get; private set; }
        public int QuestionId { get; private set; }
        public string QuestionItemTitle { get; private set; }
        public int QuestionItemValue { get; private set; }
        public string Description { get; private set; }
        public List<AnswerQuestionItem> AnswerQuestionItems { get; set; }

        //public SurveyQuestion Question { get;private set; }
        //public SurveyAnswer Answer { get;private set; }

        public void SetQuestionId(int questionId)
        {
            Guard.Argument(questionId).NotNegative().NotZero();
            QuestionId = questionId;
        }
        public void SetQuestionItemTitle(string questionItemTitle)
        {
            Guard.Argument(questionItemTitle).NotNull().NotEmpty();
            QuestionItemTitle = questionItemTitle;
        }
        public void SetQuestionItemValue(int questionItemValue)
        {
            Guard.Argument(questionItemValue).NotNegative();
            QuestionItemValue = questionItemValue;
        }
        public void SetDescription(string description)
        {
            Guard.Argument(description).MaxLength(300);
            Description = description;
        }
        //public void SetSurveyQuestion(SurveyQuestion question) => Question = question;
        //public void SetSurveyAnswer(SurveyAnswer answer) => Answer = answer;


    }
}
