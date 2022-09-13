using Dawn;
using Satisfaction.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using Satisfaction.Domain.AggregatesModel.Shared;
using Satisfaction.Domain.AggregatesModel.SurveyConfigurationAggregate;

namespace Satisfaction.Domain.AggregatesModel.SurveyConfigurationAggregate
{
    /// <summary>
    /// تنظیمات نظرسنجی
    /// </summary>
    public class SurveyConfiguration : Entity, IAggregateRoot
    {
        public SurveyConfiguration()
        {

        }
        public SurveyConfiguration(SurveyType surveyType, ImpactRate impactRate, SamplingMethod samplingMethod, int creator, DateTime creationDate)
        {
            //Guard.Argument(surveyType).NotNull();
            //Guard.Argument(impactRate).NotNull();
            //Guard.Argument(samplingMethod).NotNull();
            SurveyType = surveyType;
            ImpactRate = impactRate;
            SamplingMethod = samplingMethod;
            Creator = creator;
            CreationDate = creationDate;
        }
        public int SurveyConfigurationId { get;  set; }
        public SurveyType SurveyType { get; set; }
        public ImpactRate ImpactRate { get; set; }
        public SamplingMethod SamplingMethod { get; set; }
        public int Creator { get;  set; }
        public DateTime CreationDate { get;  set; }

        //public Survey Survey { get; set; }
    }
}
