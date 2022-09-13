namespace Satisfaction.Application.Commands.Acts
{
    public class AnswerItem
    {
        public AnswerItem()
        {
            
        }
        public AnswerItem(int surveyQuestionItemId, string description)
        {
            SurveyQuestionItemId = surveyQuestionItemId;
            Description = description;
        }
        public int SurveyQuestionItemId { get; set; }
        public string Description { get; set; }
    }
}