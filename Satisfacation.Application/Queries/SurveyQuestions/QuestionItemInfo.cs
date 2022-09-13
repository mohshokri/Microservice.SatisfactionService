namespace Satisfaction.Application.Queries.SurveyQuestions
{
    public class QuestionItemInfo
    {
        public QuestionItemInfo(int questionItemId, int questionId, string questionItemTitle, string description)
        {
            QuestionItemId = questionItemId;
            QuestionId = questionId;
            QuestionItemTitle = questionItemTitle;
            Description = description;  
        }
        public int QuestionItemId { get; set; }
        public int QuestionId { get; set; }
        public string QuestionItemTitle { get; set; }
        public string Description { get; set; }

    }
}