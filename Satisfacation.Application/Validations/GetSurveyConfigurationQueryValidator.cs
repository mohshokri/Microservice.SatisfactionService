using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Satisfaction.Application.Queries.Configurations;

namespace Satisfaction.Application.Validations
{
    public class GetSurveyConfigurationQueryValidator: AbstractValidator<GetSurveyConfigurationQuery>
    {
        public GetSurveyConfigurationQueryValidator()
        {
            RuleFor(v => v.SurveyType).NotNull().NotEmpty();
        }
    }
}
