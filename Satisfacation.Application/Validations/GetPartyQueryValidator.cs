using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Satisfaction.Application.Commands.Surveys;
using Satisfaction.Application.Queries.Parties;

namespace Satisfaction.Application.Validations
{

    public class GetPartyQueryValidator : AbstractValidator<GetPartyQuery>
    {
        public GetPartyQueryValidator()
        {
            RuleFor(v => v.FranchiseId).NotNull().NotEmpty();
        }
    }
}
