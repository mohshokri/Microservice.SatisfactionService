using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Application.Queries.Surveys
{
    public class QuestionViewModel
    {
        public QuestionViewModel(string questionTitle, int questionOrder, List<QuestionItemViewModel> questionItems)
        {
            QuestionTitle = questionTitle;
            QuestionOrder = questionOrder;
            QuestionItems = questionItems;
        }

        public int QuestionId { get; set; }
        public int SurveyId { get; set; }
        public string QuestionTitle { get; set; }
        public int QuestionOrder { get; set; }
        public bool Required { get; set; }
        public int Creator { get; set; }
        public DateTime CreationDate { get; set; }
        public List<QuestionItemViewModel> QuestionItems { get; set; }
    }
}
