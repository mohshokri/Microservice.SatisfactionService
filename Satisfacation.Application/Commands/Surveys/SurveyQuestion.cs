using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Application.Commands.Surveys
{
    public class SurveyQuestion
    {
        public SurveyQuestion(string questionTitle, int questionOrder, bool required/*, int creator*/, List<SurveyQuestionItem> questionItems)
        {
            QuestionTitle = questionTitle;
            QuestionOrder = questionOrder;
            Required = required;
            //Creator = creator;
            QuestionItems = questionItems;
        }

        public string QuestionTitle { get; }
        public int QuestionOrder { get; }
        public bool Required { get; }
        //public int Creator { get; }
        public List<SurveyQuestionItem> QuestionItems { get; }
    }
}
