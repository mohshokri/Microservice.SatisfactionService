using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Satisfaction.Application.Queries.SurveyQuestions;
using Satisfaction.Application.Services;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate;
using Satisfaction.Infrastructure.Persistence;

namespace Satisfaction.Infrastructure.Services
{
    public class SurveyQuestionQueryService : ISurveyQuestionQueryService
    {
        private readonly SatisfactionContext _context;

        public SurveyQuestionQueryService(SatisfactionContext context)
        {
            _context = context;
        }

        public Task<List<QuestionInfo>> GetQuestionListQuery(int surveyId)
        {
            return _context.Questions.Where(t => t.SurveyId == surveyId)
                .Select(t => new QuestionInfo()
                {
                    QuestionId = t.QuestionId,
                    SurveyId=t.SurveyId,
                    QuestionTitle = t.QuestionTitle,
                    QuestionOrder = t.QuestionOrder,
                    Required = t.Required,
                    QuestionItems = t.QuestionItems.Select(t => new QuestionItemInfo(t.QuestionItemId,t.QuestionId,t.QuestionItemTitle, t.Description)).ToList(),

                }).AsNoTracking()
                .ToListAsync();
        }
    }
}