using AutoMapper;
using Satisfaction.Application.Commands.Surveys;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using static Satisfaction.Application.Commands.Surveys.CreateSurveyCommand;

namespace Satisfaction.Application.MappingProfiles
{
    public class SurveyMappingProfile : Profile
    {
        public SurveyMappingProfile()
        {
            //CreateMap<CreateSurveyCommand, Survey>();
            //CreateMap<SurveyQuestionItem, SurveyQuestionItem>();
            //CreateMap<SurveyQuestion, SurveyQuestion>();
        }
    }
}
