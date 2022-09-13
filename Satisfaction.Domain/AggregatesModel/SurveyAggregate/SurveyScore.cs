using Dawn;
using System;
using System.Collections.Generic;
using System.Text;
using static Satisfaction.Domain.Enumerations.Enumeration;

namespace Satisfaction.Domain.AggregatesModel.SurveyAggregate
{
    public class SurveyScore
    {
        private SurveyScore()
        {

        }
        public SurveyScore(int surveyId,int minScore,int maxScore,SatisfactionRate satisfactionRate)
        {
            Guard.Argument(SurveyId).Positive();
            Guard.Argument(minScore).Positive();
            Guard.Argument(maxScore).Positive();
            SurveyId = surveyId;
            MinScore = minScore;
            MaxScore = maxScore;
            SatisfactionRate = satisfactionRate;
        }
        public int SurveyScoreId { get;private set; }
        public int SurveyId { get;private set; }
        public int MinScore { get;private set; }
        public int MaxScore { get;private set; }
        public SatisfactionRate SatisfactionRate { get;private set; }

        //public Survey Survey { get; set; }

        public void SetSurveyId(int surveyId)
        {
            Guard.Argument(surveyId).NotNegative().NotZero();
            SurveyId = surveyId;
        }
        public void SetMinScore(int minScore)
        {
            Guard.Argument(minScore).NotNegative();
            MinScore = minScore;
        }
        public void SetMaxScore(int maxScore)
        {
            Guard.Argument(maxScore).NotNegative();
            MaxScore = maxScore;
        }
        public void SetSatisfactionRate(SatisfactionRate satisfactionRate)
        {
            Guard.Argument(SatisfactionRate).NotNull();
            SatisfactionRate = satisfactionRate;
        }
    }
}
