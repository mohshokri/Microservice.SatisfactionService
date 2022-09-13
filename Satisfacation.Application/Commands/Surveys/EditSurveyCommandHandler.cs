using MediatR;
using Satisfaction.Domain.AggregatesModel.Shared;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using QItemCommand = Satisfaction.Domain.AggregatesModel.SurveyAggregate;

namespace Satisfaction.Application.Commands.Surveys
{
    public class EditSurveyCommandHandler : AsyncRequestHandler<EditSurveyCommand>
    {
        private readonly ISurveyRepository _surveyRepository;
        public EditSurveyCommandHandler(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }
        protected override async Task Handle(EditSurveyCommand request, CancellationToken cancellationToken)
        {
            var survey = await _surveyRepository.GetAsync(request.SurveyId);
            if (survey == null) throw new Exception($"Survey {request.SurveyId} Not Found");
            //if(survey.IsAnswered)
            survey.SetSurveyCode(request.SurveyCode);
            survey.SurveyType = request.SurveyType;
            survey.SetSurveyTitle(request.SurveyTitle);
            survey.SetActivationState(request.IsActive);
            var activationRange = new DateRange(request.StartDate, request.EndDate);
            survey.SetActivationRange(activationRange);
            var surveyImage = new SurveyImage(request.LogoAttachmentContent, request.LogoFileExtention);
            survey.SetSurveyImage(surveyImage);

            foreach (var item in request.Questions)
            {                
                var qItems = item.QuestionItems.Select(s => new QItemCommand.SurveyQuestionItem(s.QuestionItemTitle)).ToList();
                survey.AddQuestion(item.QuestionTitle, item.QuestionOrder, item.Required,/* item.Creator,DateTime.Now,*/ qItems);
            }
        }
    }
}
