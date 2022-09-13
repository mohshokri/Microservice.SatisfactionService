using Dawn;
using Satisfaction.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Satisfaction.Domain.AggregatesModel.SurveyAggregate
{
    public class SurveyQuestion : Entity
    {
        private SurveyQuestion()
        {
            _questionItems = new List<SurveyQuestionItem>();
        }
        public SurveyQuestion( string questionTitle, int questionOrder, bool required/*, int creator, DateTime creationDate*/)
        {
            Guard.Argument(questionTitle).NotWhiteSpace();
            Guard.Argument(questionOrder).Positive();
            //Guard.Argument(creator).Positive();
            QuestionTitle = questionTitle;
            QuestionOrder = questionOrder;
            Required = required;
            //Creator = creator;
            //CreationDate = creationDate;
            _questionItems = new List<SurveyQuestionItem>();

        }

        public int QuestionId { get; private set; }
        public int SurveyId { get; private set; }
        public string QuestionTitle { get; private set; }
        public int QuestionOrder { get; private set; }
        public bool Required { get; private set; }
        //public int Creator { get;private set; }
        //public DateTime CreationDate { get;private set; }
        //public Survey Survey { get; private set; }
        private readonly List<SurveyQuestionItem> _questionItems;
        public IReadOnlyCollection<SurveyQuestionItem> QuestionItems => _questionItems;

        public void SetSurveyId(int surveyId)
        {
            Guard.Argument(surveyId).NotNegative().NotZero();
            SurveyId = surveyId;
        }
        public void SetQuestionTitle(string questionTitle)
        {
            Guard.Argument(questionTitle).NotNull().NotEmpty();
            QuestionTitle = questionTitle;
        }
        public void SetRequiredState(bool required)
        {
            if (required == Required) return;
            Required = required;
        }
        //public void SetSurvey(Survey survey) => Survey = survey;

        //public void AddQuestionItem(string questionItemTitle, int questionItemValue, string description)
        //{
        //    Guard.Argument(questionItemTitle).NotEmpty();
        //    if (_questionItems.Any(c => c.QuestionItemTitle == questionItemTitle)) throw new BusinessRuleValidationException("Duplicate QuestionItemTitle!");
        //    _questionItems.Add(new SurveyQuestionItem(questionItemTitle,questionItemValue,description));
        //}

        public void AddQuestionItem(string questionItemTitle,int questionItemValue)
        {
            Guard.Argument(questionItemTitle).NotEmpty();             
            if (_questionItems.Any(c => c.QuestionItemTitle == questionItemTitle)) throw new BusinessRuleValidationException("Duplicate QuestionItemTitle!");
            var value = (_questionItems?.Count() ?? 0) + 1;
            var qItem = new SurveyQuestionItem(questionItemTitle, value);
            _questionItems.Add(qItem);
        }

        public void RemoveQuestionItem(int questionItemId)
        {
            var item = _questionItems.SingleOrDefault(t => t.QuestionItemId == questionItemId);
            _questionItems.Remove(item);
        }
    }
}
