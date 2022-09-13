using Dawn;
using Satisfaction.Domain.AggregatesModel.Shared;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate.DomainEvents;
using Satisfaction.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Satisfaction.Domain.AggregatesModel.SurveyAggregate
{
    public class Survey : Entity, IAggregateRoot
    {
        private Survey()
        {
            _questions = new List<SurveyQuestion>();
            _surveyScores = new List<SurveyScore>();
        }
        public Survey(int partyId, string surveyCode, SurveyType surveyType, string surveyTitle
                       ,SurveyImage surveyImage, bool isActive, DateRange activationRange
                       , int creator, DateTime creationDate)
        {
           // Guard.Argument(partyId).Positive();
            Guard.Argument(surveyCode).NotNull().NotEmpty();
            Guard.Argument(surveyTitle).NotNull().NotEmpty();
            PartyId = partyId;
            SurveyCode = surveyCode;
            SurveyType = surveyType;
            SurveyTitle = surveyTitle;
            SurveyImage = surveyImage;
            IsActive = isActive;
            ActivationRange = activationRange;
            Creator = creator;
            CreationDate = creationDate;
            _questions = new List<SurveyQuestion>();
            _surveyScores = new List<SurveyScore>();
        }

        public int SurveyId { get; private set; }
        public int PartyId { get; private set; }
        public string SurveyCode { get; private set; }
        public SurveyType SurveyType { get; set; }
        public string SurveyTitle { get; private set; }
        public bool IsActive { get; private set; }
        public SurveyImage SurveyImage { get; set; }
        public DateRange ActivationRange { get; private set; }
        public int Creator { get; private set; }
        public DateTime CreationDate { get; private set; }
        public int? Modifier { get; set; }
        public DateTime? ModificationDate { get; set; }
        private readonly List<SurveyQuestion> _questions;
        public IReadOnlyCollection<SurveyQuestion> Questions => _questions;
        private readonly List<SurveyScore> _surveyScores;
        public IReadOnlyCollection<SurveyScore> SurveyScores => _surveyScores;

        public void AddQuestion(string questionTitle, int questionOrder, bool required,/* int creator, DateTime creationDate,*/List<SurveyQuestionItem> questionItems)
        {
            Guard.Argument(questionTitle).NotNull().NotWhiteSpace();
            Guard.Argument(questionOrder).Positive();

            if (_questions.Any(c => c.QuestionTitle == questionTitle)) throw new BusinessRuleValidationException("Duplicate QuestionTitle!");
            var surveyQuestion = new SurveyQuestion(questionTitle, questionOrder, required/*, creator, creationDate*/);
            foreach (var item in questionItems)
            {
                surveyQuestion.AddQuestionItem(item.QuestionItemTitle,item.QuestionItemValue);
            }
            _questions.Add(surveyQuestion);

        }
        public void RemoveQuestion(int questionId)
        {
            var item = _questions.SingleOrDefault(c => c.QuestionId == questionId);
            _questions.Remove(item);
        }
        public void AddSurveyScore(int surveyScoreId, int surveyId, int minScore, int maxScore, SatisfactionRate satisfactionRate)
        {
            Guard.Argument(SurveyId).Positive();
            Guard.Argument(minScore).Positive();
            Guard.Argument(maxScore).Positive();
            if (_surveyScores.Any(c => c.SurveyScoreId == surveyScoreId)) throw new BusinessRuleValidationException("Duplicate SurveyScore!");
            _surveyScores.Add(new SurveyScore(surveyId, minScore, maxScore, satisfactionRate));
        }
        public void RemoveSurveyScore(int surveyScoreId)
        {
            var item = _surveyScores.SingleOrDefault(c => c.SurveyScoreId == surveyScoreId);
            _surveyScores.Remove(item);
        }
        public void SetPartyId(int partyId)
        {
            //if (partyId <= 0)
            //    throw new ArgumentException("Interest Id must be greater than 0!");
            //PartyId = partyId;
            Guard.Argument(partyId).NotNegative().NotZero();
            PartyId = partyId;
        }
        public void SetSurveyCode(string surveyCode)
        {
            //if (String.IsNullOrEmpty(surveyCode))
            //    throw new Exception("SurveyCode must not be null or empty!");
            //SurveyCode = surveyCode;

            Guard.Argument(surveyCode).NotNull().NotWhiteSpace();
            SurveyCode = surveyCode;
        }
        public void SetSurveyTitle(string surveyTitle)
        {
            //if (String.IsNullOrEmpty(surveyTitle))
            //    throw new Exception("SurveyTitle must not be null or empty!");
            //SurveyTitle = SurveyTitle;

            Guard.Argument(surveyTitle).NotNull().NotEmpty();
            SurveyTitle = surveyTitle;
        }
        public void SetActivationState(bool active)
        {
            if (active == IsActive) return;
            IsActive = active;

            if (IsActive)
            {
                AddDomainEvent(new SurveyActivated(SurveyCode));
            }
            else
            {
                AddDomainEvent(new SurveyDeactivated());
            }
        }
        public void SetActivationRange(DateRange date)
        {
            ActivationRange = date;
        }
        public void SetSurveyImage(SurveyImage surveyImage)
        {
            SurveyImage = surveyImage;
        }
        //public void SetSurveyType(SurveyType surveyType)
        //{
        //    SurveyType = surveyType;
        //}

        // public void SetActivateDateRange(DateRange dateRange) => ActiveDateRange = dateRange;

    }
}
