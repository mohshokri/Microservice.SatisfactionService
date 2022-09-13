using MediatR;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using Satisfaction.Domain.AggregatesModel.Shared;

namespace Satisfaction.Application.Commands.Surveys
{
    public class EditSurveyCommand : IRequest
    {
        public int SurveyId { get; }
        public string SurveyCode { get; }
        public SurveyType SurveyType { get; }
        public string SurveyTitle { get; }
        public byte[] LogoAttachmentContent { get; }
        public string LogoFileExtention { get; }
        public bool IsActive { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public List<SurveyQuestion> Questions { get; }
        public int Creator { get; }

        public EditSurveyCommand(string surveyCode, SurveyType surveyType, string surveyTitle,
                                  byte[] logoAttachmentContent, string logoFileExtention,
                                  bool isActive, DateTime startDate, DateTime endDate, 
                                  List<SurveyQuestion> questions, int creator)
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
