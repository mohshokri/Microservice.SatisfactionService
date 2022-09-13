using System.Collections.Generic;
using MediatR;

namespace Satisfaction.Application.Queries.SurveyQuestions
{
    public class QuestionQuery : IRequest<List<QuestionInfo>>
    {
        public int SurveyId { get; set; }
    }
}