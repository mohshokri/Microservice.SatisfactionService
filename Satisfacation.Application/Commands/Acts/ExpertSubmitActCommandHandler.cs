using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.VisualBasic;
using Satisfaction.Domain.AggregatesModel.ActAggregate;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate;

namespace Satisfaction.Application.Commands.Acts
{
    
    public class ExpertSubmitActCommandHandler:AsyncRequestHandler<ExpertSubmitActCommand>
    {
        private readonly IActRepository _actRepository;

        public ExpertSubmitActCommandHandler(IActRepository actRepository)
        {
            _actRepository = actRepository;
        }

        protected override async Task Handle(ExpertSubmitActCommand request, CancellationToken cancellationToken)
        {
            //sakhte answer items
            var items = new List<AnswerQuestionItem>();
            if (request.AnswerItems.Any())
            {
                 items = request.AnswerItems.Select(s => new AnswerQuestionItem()
                {
                    Description=s.Description,
                    QuestionItemId=s.SurveyQuestionItemId
                }).ToList();
            }

            var surveyAnswer = new SurveyAnswer(request.AssignedChassisId, items);

            var customerStateId = CustomerState.FromValue(request.CustomerStateId);
            var contactTypeId = ContactType.FromValue(request.ContactTypeId);
            
            var act = new Act(request.AssignedChassisId, request.IsSuccessCall, items.Any(),
                surveyAnswer.AnswerId, customerStateId, request.ActDate, request.AlarmDate, request.AlarmTime,
                request.AlarmDescription, contactTypeId,
                null, request.Creator, DateTime.UtcNow, request.AssignedChassisId, surveyAnswer);

            await _actRepository.AddAsync(act);
        }
    }
}