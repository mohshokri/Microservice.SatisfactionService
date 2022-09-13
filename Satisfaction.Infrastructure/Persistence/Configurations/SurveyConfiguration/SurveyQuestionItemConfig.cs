using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate;

namespace Satisfaction.Infrastructure.Persistence.Configurations.SurveyConfiguration
{
    public class SurveyQuestionItemConfig : IEntityTypeConfiguration<SurveyQuestionItem>
    {
        public void Configure(EntityTypeBuilder<SurveyQuestionItem> builder)
        {
            builder.HasKey(p => p.QuestionItemId);
            builder.Property(p => p.QuestionItemId).IsRequired();
            builder.Property(p => p.QuestionId).IsRequired();
            builder.Property(p => p.QuestionItemTitle).IsRequired().HasMaxLength(40);
            builder.Property(p => p.QuestionItemValue).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200);

           
            //builder.HasOne<SurveyQuestion>().WithMany().HasForeignKey(p => p.QuestionId);
            builder.HasMany(p=>p.AnswerQuestionItems).WithOne().HasForeignKey(p => p.QuestionItemId);


        }
    }
}
