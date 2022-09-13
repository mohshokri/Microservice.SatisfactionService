using Satisfaction.Domain.SeedWork;

namespace Satisfaction.Domain.AggregatesModel.SurveyAggregate
{
    public class AnswerQuestionItem : Entity
    {
        public AnswerQuestionItem()
        {
            
        }
        //public AnswerQuestionItem(int answerQuestionItemId, int questionItemId, string description)
        //{
        //    AnswerQuestionItemId = answerQuestionItemId;
        //    QuestionItemId = questionItemId;
        //    Description = description;
        //}
        public int AnswerQuestionItemId { get; set; }
        public int AnswerId { get; set; }

        public int QuestionItemId { get; set; }
        public string Description { get; set; }
    }
}