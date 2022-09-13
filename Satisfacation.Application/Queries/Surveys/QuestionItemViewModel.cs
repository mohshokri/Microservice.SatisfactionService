using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Application.Queries.Surveys
{
    public class QuestionItemViewModel
    {
        public QuestionItemViewModel(string questionItemTitle)
        {
            QuestionItemTitle = questionItemTitle;
        }

        public int QuestionItemId { get; set; }
        public int QuestionId { get; set; }
        public string QuestionItemTitle { get; set; }
    }
}
