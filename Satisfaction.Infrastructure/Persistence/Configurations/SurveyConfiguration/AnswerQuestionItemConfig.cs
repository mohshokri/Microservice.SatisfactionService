using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate;

namespace Satisfaction.Infrastructure.Persistence.Configurations.SurveyConfiguration
{
    public class AnswerQuestionItemConfig : IEntityTypeConfiguration<AnswerQuestionItem>
    {
        public void Configure(EntityTypeBuilder<AnswerQuestionItem> builder)
        {
            builder.HasKey(p => p.AnswerQuestionItemId);
            builder.Property(p => p.AnswerQuestionItemId).IsRequired();
            builder.Property(p => p.QuestionItemId).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(400);

            //builder.HasMany<AnswerQuestionItem>().WithOne().HasForeignKey(p => p.AnswerQuestionItemId);
            //builder.HasOne<SurveyQuestionItem>().WithMany().HasForeignKey(p => p.QuestionItemId);

        }
    }
}