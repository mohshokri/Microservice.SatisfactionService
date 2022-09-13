using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate;

namespace Satisfaction.Infrastructure.Persistence.Configurations.SurveyConfiguration
{
    public class SurveyAnswerConfig : IEntityTypeConfiguration<SurveyAnswer>
    {
        public void Configure(EntityTypeBuilder<SurveyAnswer> builder)
        {
            builder.HasKey(p => p.AnswerId);
            builder.Property(p => p.AnswerId).IsRequired();
            //builder.Property(p => p.QuestionItemId).IsRequired();
            builder.Property(p => p.AssignedChassisId).IsRequired();
            builder.Property(p => p.Date).IsRequired();

            //builder.HasOne(p => p.Act).WithMany(p => p.SurveyAnswers).HasForeignKey(p => p.AnswerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p=>p.AnswerQuestionItems).WithOne().HasForeignKey(p => p.AnswerId);

        }
    }
}
