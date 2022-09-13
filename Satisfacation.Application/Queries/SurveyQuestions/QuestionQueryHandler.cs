using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Satisfaction.Application.Services;

namespace Satisfaction.Application.Queries.SurveyQuestions
{
    public class QuestionQueryHandler : IRequestHandler<QuestionQuery, List<QuestionInfo>>
    {
        private readonly ISurveyQuestionQueryService _surveyQuestionQueryService;

        public QuestionQueryHandler(ISurveyQuestionQueryService surveyQuestionQueryService)
        {
            _surveyQuestionQueryService = surveyQuestionQueryService;
        }
        public async Task<List<QuestionInfo>> Handle(QuestionQuery request, CancellationToken cancellationToken)
        {
            return await _surveyQuestionQueryService.GetQuestionListQuery(request.SurveyId);
        }
    }
}