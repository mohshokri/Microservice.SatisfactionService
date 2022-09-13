using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Satisfaction.Domain.AggregatesModel.Shared;
using Satisfaction.Domain.AggregatesModel.SurveyConfigurationAggregate;


namespace Satisfaction.Application.Queries.Configurations
{
    public class GetSurveyConfigurationQueryHandler:IRequestHandler<GetSurveyConfigurationQuery,SurveyConfigurationList>
    {
        private readonly ISurveyConfigurationRepository _surveyConfigurationRepository;
        

        public GetSurveyConfigurationQueryHandler(ISurveyConfigurationRepository surveyCfgRepository)
        {
            _surveyConfigurationRepository = surveyCfgRepository;
        }
        public async Task<SurveyConfigurationList> Handle(GetSurveyConfigurationQuery request, CancellationToken cancellationToken)
        {
            //var surveyType = SurveyType.FromValue(request.SurveyType);

            var surveyConfigurations = _surveyConfigurationRepository.GetSurveyConfigurationList(request.SurveyType)
                .Select(t=> new SurveyConfiguration
                {
                    SurveyType = t.SurveyType,
                    ImpactRate = t.ImpactRate,
                    SamplingMethod = t.SamplingMethod
                }).ToList();
            if (!surveyConfigurations.Any())
                throw new Exception("نوع نظرسنجی را انتخاب کنید"); 
            return new SurveyConfigurationList { SurveyConfigurations = surveyConfigurations }; 
        }
    }
}
