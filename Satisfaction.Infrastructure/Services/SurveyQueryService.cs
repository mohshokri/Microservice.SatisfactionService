using Microsoft.EntityFrameworkCore;
using Satisfaction.Domain.AggregatesModel.Shared;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate;
using Satisfaction.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Satisfaction.Application.Queries.Surveys;
using Satisfaction.Application.Services;

namespace Satisfaction.Infrastructure.Services
{
    public class SurveyQueryService : ISurveyQueryService
    {
        private readonly SatisfactionContext _satisfactionContext;
        private readonly ISurveyRepository _surveyRepository;
        public SurveyQueryService(SatisfactionContext satisfactionContext, ISurveyRepository surveyRepository)
        {
            _satisfactionContext = satisfactionContext;
            _surveyRepository = surveyRepository;
        }

        public async Task<List<SurveyListViewModel>> GetSurveyListQuery()
        {

            return await _satisfactionContext.Surveys.Select(s => new SurveyListViewModel
            {
                SurveyTitle = s.SurveyTitle,
                SurveyType = s.SurveyType,
                SurveyId = s.SurveyId,
                SurveyCode = s.SurveyCode,

            }).ToListAsync();
        }

        public async Task<SurveyViewModel> GetSelectedSurvey(int surveyId)
        {
            // var survey = _satisfactionContext.Surveys.Include(t => t.Questions).ThenInclude(y => y.QuestionItems).SingleOrDefault(t => t.SurveyId == surveyId);
            // var viewmodel = new SurveyViewModel();

            var survey = await _surveyRepository.GetAsync(surveyId);

            //var surveyImage = new SurveyImage(survey.LogoAttachmentContent, survey.LogoFileExtention);

            var surveyViewModel = new SurveyViewModel();
            surveyViewModel.SurveyCode = survey.SurveyCode;
            surveyViewModel.SurveyType = survey.SurveyType;
            surveyViewModel.SurveyTitle = survey.SurveyTitle;
            surveyViewModel.LogoAttachmentContent = survey.SurveyImage.LogoAttachmentContent;
            surveyViewModel.LogoFileExtention = survey.SurveyImage.LogoFileExtention;

            var questionList = survey.Questions.Select(q =>
            {
                var questionItems = q.QuestionItems.Select(s => { return new QuestionItemViewModel(s.QuestionItemTitle); }).ToList();
                return new QuestionViewModel(q.QuestionTitle, q.QuestionOrder, questionItems);
            }).ToList();

            surveyViewModel.Questions = questionList;
            return surveyViewModel;
        }

        
    }
}
