using System;
using System.Collections.Generic;
using Satisfaction.Domain.AggregatesModel.Shared;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate;

namespace Satisfaction.Application.DTOs
{
    public class EditSurveyRequest
    {
        public int SurveyId { get; set; }
        public string SurveyCode { get; set; }
        public SurveyType SurveyType { get; set; }
        public string SurveyTitle { get; set; }
        public byte[] LogoAttachmentContent { get; set; }
        public string LogoFileExtention { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<SurveyQuestionRequest> Questions { get; set; }
        public int Creator { get; set; }
        public EditSurveyRequest()
        {

        }
        public EditSurveyRequest(string surveyCode, SurveyType surveyType, string surveyTitle,
                                  byte[] logoAttachmentContent, string logoFileExtention,
                                  bool isActive, DateTime startDate, DateTime endDate,
                                  List<SurveyQuestionRequest> questions, int creator)
        {
            SurveyCode = surveyCode;
            SurveyType = surveyType;
            SurveyTitle = surveyTitle;
            LogoAttachmentContent = logoAttachmentContent;
            LogoFileExtention = logoFileExtention;
            IsActive = isActive;
            StartDate = startDate;
            EndDate = endDate;
            Questions = questions;
            Creator = creator;
        }
    }
}
