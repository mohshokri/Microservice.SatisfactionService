using MediatR;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Satisfaction.Application.Commands.Surveys
{
    public class RemoveSurveyCommandHandler : AsyncRequestHandler<RemoveSurveyCommand>
    {
        //private readonly SatisfactionContext _satisfactionContext;
        //private readonly ISurveyRepository _repository;
        //public RemoveSurveyCommandHandler(SatisfactionContext satisfactionContext,ISurveyRepository repository)
        //{
        //    _satisfactionContext = satisfactionContext;
        //    _repository = repository;
        //}
        //protected override async Task Handle(RemoveSurveyCommand request, CancellationToken cancellationToken)
        //{
        //    var survey =await _repository.GetAsync(request.SurveyId);
        //    if (survey != null) _satisfactionContext.Remove(survey);
        //}
        protected override async Task Handle(RemoveSurveyCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
