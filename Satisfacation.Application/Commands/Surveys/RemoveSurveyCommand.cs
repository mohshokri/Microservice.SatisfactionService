using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Application.Commands.Surveys
{
    public class RemoveSurveyCommand:IRequest
    {
        public int SurveyId { get; }
        public RemoveSurveyCommand(int surveyId)
        {
            SurveyId = surveyId;
        }
    }
}
