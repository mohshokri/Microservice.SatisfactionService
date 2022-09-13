using Satisfaction.Domain.AggregatesModel.Shared;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Application.Queries.Surveys
{
    public class SurveyViewModel
    {
        public int SurveyId { get; set; }
        public int PartyId { get; set; }
        public string SurveyCode { get; set; }
        public SurveyType SurveyType { get; set; }
        public string SurveyTitle { get; set; }
        public byte[] LogoAttachmentContent { get; set; }
        public string LogoFileExtention { get; set; }
        //public string StartDate { get; set; }
        //public string EndDate { get; set; }
        //public bool IsEdited { get; set; }
        public List<QuestionViewModel> Questions{ get; set; }
    }
}
