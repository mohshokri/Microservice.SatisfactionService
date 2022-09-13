using MediatR;
using Satisfaction.Domain.AggregatesModel.Shared;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Application.Commands.Surveys
{
    public class CreateSurveyCommand : IRequest
    {
        public string SurveyCode { get; }
        public SurveyType SurveyType { get; }
        public string SurveyTitle { get; }
        // public DateRange ActivationRange { get; }
        //public SurveyImage SurveyImage { get; }
        public byte[] LogoAttachmentContent { get; }
        public string LogoFileExtention { get; }
        public bool IsActive { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public List<SurveyQuestion> Questions { get; }     
        public int Creator { get; }


        public CreateSurveyCommand(string surveyCode, SurveyType surveyType, string surveyTitle,
            /*DateRange activationRange,*/ /*SurveyImage surveyImage,*/ byte[] logoAttachmentContent,string logoFileExtention,
            bool isActive, DateTime startDate, DateTime endDate, List<SurveyQuestion> questions, int creator)
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
