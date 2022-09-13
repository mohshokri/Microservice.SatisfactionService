using System.Collections.Generic;

namespace Satisfaction.Application.DTOs
{

    public class SurveyQuestionRequest
    {

        public SurveyQuestionRequest()
        {

        }
        public SurveyQuestionRequest(string questionTitle, int questionOrder, bool required,/* int creator,*/ List<SurveyQuestionItemRequest> questionItems)
        {
            QuestionTitle = questionTitle;
            QuestionOrder = questionOrder;
            Required = required;
            //Creator = creator;
            QuestionItems = questionItems;
        }

        public string QuestionTitle { get; set; }
        public int QuestionOrder { get; set; }
        public bool Required { get; set; }
        //public int Creator { get; set; }
        public List<SurveyQuestionItemRequest> QuestionItems { get; set; }
    }

}
