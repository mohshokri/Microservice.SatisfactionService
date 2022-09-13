using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate;

namespace Satisfaction.Infrastructure.Persistence.Configurations.SurveyConfiguration
{
    public class SurveyQuestionConfig : IEntityTypeConfiguration<SurveyQuestion>
    {
        public void Configure(EntityTypeBuilder<SurveyQuestion> builder)
        {
            builder.HasKey(p => p.QuestionId);
            builder.Property(p => p.QuestionId).IsRequired();
            builder.Property(p => p.SurveyId).IsRequired();
            builder.Property(p => p.QuestionTitle).IsRequired().HasMaxLength(500);
            builder.Property(p => p.QuestionOrder).IsRequired();
            builder.Property(p => p.Required).IsRequired();
            //builder.Property(p => p.Creator).IsRequired();
            //builder.Property(p => p.CreationDate).IsRequired();

            //builder.HasOne(p => p.Survey).WithMany(p => p.Questions).HasForeignKey(p => p.SurveyId).OnDelete(DeleteBehavior.Cascade);
            //az Question be QuestionItem benevisim behtare
            builder.HasMany(p => p.QuestionItems).WithOne().HasForeignKey(p => p.QuestionId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
