using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Application.Commands.Surveys
{
    public class SurveyQuestionItem
    {
        public SurveyQuestionItem(string questionItemTitle)
        {
            QuestionItemTitle = questionItemTitle;
        }
        public string QuestionItemTitle { get; }
    }
}
