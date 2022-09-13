namespace Satisfaction.Application.DTOs
{

    public class SurveyQuestionItemRequest
    {

        public SurveyQuestionItemRequest()
        {

        }
        public SurveyQuestionItemRequest(string questionItemTitle)
        {
            QuestionItemTitle = questionItemTitle;
        }
        public string QuestionItemTitle { get; set; }

    }
}
