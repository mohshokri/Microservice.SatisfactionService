using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate;

namespace Satisfaction.Infrastructure.Persistence.Configurations.SurveyConfiguration
{
    public class SurveyScoreConfig : IEntityTypeConfiguration<SurveyScore>
    {
        public void Configure(EntityTypeBuilder<SurveyScore> builder)
        {
            builder.HasKey(p => p.SurveyScoreId);
            builder.Property(p => p.SurveyScoreId).IsRequired();
            builder.Property(p => p.MinScore).IsRequired();
            builder.Property(p => p.MaxScore).IsRequired();
            //Enum RelationShip
            builder.Property(p => p.SatisfactionRate).IsRequired().HasConversion(p => p.Value, p => SatisfactionRate.FromValue(p));

            //builder.HasOne(p => p.Survey).WithMany(p => p.SurveyScores).HasForeignKey(p => p.SurveyId).OnDelete(DeleteBehavior.Cascade); ;

        }
    }
}
