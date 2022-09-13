using FluentValidation;
using Satisfaction.Application.Commands.Surveys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Satisfaction.Application.Commands.Surveys.CreateSurveyCommand;

namespace Satisfaction.Application.Validations
{
    public class CreateSurveyCommandValidator : AbstractValidator<CreateSurveyCommand>
    {
        public CreateSurveyCommandValidator()
        {
            RuleFor(v => v.SurveyCode).NotNull().NotEmpty();
            RuleFor(v => v.SurveyType).NotEmpty();
            RuleFor(v => v.SurveyTitle).NotEmpty();
            RuleFor(v => v.StartDate).NotEmpty();
            RuleFor(v => v.EndDate).NotEmpty().GreaterThan(v => v.StartDate);
            //RuleFor(v => v.EndDate).NotEmpty().GreaterThanOrEqualTo(v => v.StartDate.Value).When(v => v.StartDate.HasValue);
            //RuleFor(v => v.Questions).Must(ContainQuestions);
            //RuleFor(v => v.QuestionItems).Must(ContainQuestionItems);
            RuleForEach(v => v.Questions).SetValidator(new QuestionValidator());
            RuleFor(v => v.Creator).NotEmpty();
        }

        //Custom Validation
        private bool ContainQuestions(IEnumerable<SurveyQuestion> questions)
        {
            return questions.Any();
        }
        private bool ContainQuestionItems(IEnumerable<SurveyQuestionItem> questionItems)
        {
            return questionItems.Any();
        }

        public class QuestionValidator:AbstractValidator<SurveyQuestion>
        {
            public QuestionValidator()
            {
                RuleForEach(v => v.QuestionItems).SetValidator(new QuestionItemValidator());
                RuleFor(v=>v.QuestionTitle).NotEmpty();
                RuleFor(v=>v.QuestionOrder).GreaterThan(0);
                //RuleFor(v => v.Creator).GreaterThan(0);
            }
        }

        public class QuestionItemValidator:AbstractValidator<SurveyQuestionItem>
        {
            public QuestionItemValidator()
            {
                RuleFor(v => v.QuestionItemTitle).NotEmpty();
               // RuleFor(v => v.QuestionItemValue).GreaterThanOrEqualTo(0);
            }
        }

        //public class ProductValidator : AbstractValidator<Product>
        //{
        //    public ProductValidator()
        //    {
        //        RuleForEach(x => x.ProductVariants).SetValidator(new ProductVariantValidator());
        //    }
        //}
        //public class ProductVariantValidator : AbstractValidator<ProductVariant>
        //{
        //    public ProductVariantValidator()
        //    {
        //        RuleForEach(x => x.Prices).SetValidator(new PriceValidator());
        //    }
        //}
        //public class PriceValidator : AbstractValidator<Price>
        //{
        //    public PriceValidator()
        //    {
        //        RuleFor(x => x.Price).GreaterThan(0);
        //    }
        //}




        //      RuleFor(x => x.Orders)
        //.Must(x => x.Orders.Count <= 10).WithMessage("No more than 10 orders are allowed")
        //.ForEach(orderRule => {
        //          orderRule.Must(order => order.Total > 0).WithMessage("Orders must have a total of more than 0")
        //});
    }

}

