using AutoMapper;
using MediatR;
using Satisfaction.Domain.AggregatesModel.Shared;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate;
using Satisfaction.Domain.SeedWork;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using QItemCommand = Satisfaction.Domain.AggregatesModel.SurveyAggregate;

namespace Satisfaction.Application.Commands.Surveys
{
    public class CreateSurveyCommandHandler : AsyncRequestHandler<CreateSurveyCommand>
    {
        private readonly ISurveyRepository _repository;
      // private readonly IUnitOfWork _unitOfWork;
        // private readonly IMapper _mapper;
        public CreateSurveyCommandHandler(ISurveyRepository repository/*, IUnitOfWork unitOfWork*/)
        {
            _repository = repository;
           // _unitOfWork = unitOfWork;
            // _mapper = mapper;

        }
        protected override async Task Handle(CreateSurveyCommand request, CancellationToken cancellationToken)
        {
            var date = DateTime.UtcNow;
            var activationRange = new DateRange(request.StartDate, request.EndDate);
            var surveyImage = new SurveyImage(request.LogoAttachmentContent, request.LogoFileExtention);
            //var question = _mapper.Map<SurveyQuestion>(request);
            //var questionItem = _mapper.Map<SurveyQuestionItem>(request);
            //var survey = _mapper.Map<Survey>(request);
            //await _repository.Add(survey);

            var survey = new Survey(request.Creator
                , request.SurveyCode
                , request.SurveyType
                , request.SurveyTitle
                , surveyImage
                , request.IsActive
                , activationRange
                , request.Creator
                , date);

            // map list<SurveyQuestionCommand> to list<surveyQuestion>
            foreach (var item in request.Questions)
            {
                ///map SurveyQuestionCommand to surveyQuestion
                var qItems = item.QuestionItems.Select(s => new QItemCommand.SurveyQuestionItem(s.QuestionItemTitle)).ToList();
                survey.AddQuestion(item.QuestionTitle, item.QuestionOrder, item.Required,/* item.Creator, date,*/ qItems);
            }

            await _repository.Add(survey);
            //await _unitOfWork.SaveChangesAsync(cancellationToken);

        }
    }
}
