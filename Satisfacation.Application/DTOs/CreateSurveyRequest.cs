using System;
using System.Collections.Generic;
using Satisfaction.Domain.AggregatesModel.Shared;

namespace Satisfaction.Application.DTOs
{
    public /*partial*/ class CreateSurveyRequest
    {
        public string SurveyCode { get; set; }
        public int SurveyType { get; set; }
        public string SurveyTitle { get; set; }
        // public DateRange ActivationRange { get; }
        //public SurveyImage SurveyImage { get; }
        public byte[] LogoAttachmentContent { get; set; }
        public string LogoFileExtention { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<SurveyQuestionRequest> Questions { get; set; }
        public int Creator { get; set; }
        public CreateSurveyRequest()
        {

        }
        public CreateSurveyRequest(string surveyCode, SurveyType surveyType, string surveyTitle,
            /*DateRange activationRange,*/ /*SurveyImage surveyImage,*/ byte[] logoAttachmentContent, string logoFileExtention,
            bool isActive, DateTime startDate, DateTime endDate, List<SurveyQuestionRequest> questions, int creator)
        {
            SurveyCode = surveyCode;
            SurveyType = surveyType;
            SurveyTitle = surveyTitle;
            //ActivationRange = activationRange;
            //SurveyImage = surveyImage;
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
