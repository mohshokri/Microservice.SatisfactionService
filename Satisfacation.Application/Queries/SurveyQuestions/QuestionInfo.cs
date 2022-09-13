using System;
using System.Collections.Generic;

namespace Satisfaction.Application.Queries.SurveyQuestions
{
    public class QuestionInfo
    {
        public QuestionInfo()
        {
        }

        public QuestionInfo(int questionId, int surveyId, string questionTitle, int questionOrder, bool required, List<QuestionItemInfo> questionItems)
        {
            QuestionId = questionId;
            SurveyId = surveyId;
            QuestionTitle = questionTitle;
            QuestionOrder = questionOrder;
            Required = required;
            QuestionItems = questionItems;  
        }
        public int QuestionId { get; set; }
        public int SurveyId { get; set; }
        public string QuestionTitle { get; set; }
        public int QuestionOrder { get; set; }
        public bool Required { get; set; }
        public List<QuestionItemInfo> QuestionItems { get; set; }
    }
}