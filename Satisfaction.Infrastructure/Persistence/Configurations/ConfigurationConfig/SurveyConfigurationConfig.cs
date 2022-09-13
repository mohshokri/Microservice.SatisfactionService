using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Satisfaction.Domain.AggregatesModel.Shared;
using Satisfaction.Domain.AggregatesModel.SurveyConfigurationAggregate;

namespace Satisfaction.Infrastructure.Persistence.Configurations.ConfigurationConfig
{
    public class SurveyConfigurationConfig : IEntityTypeConfiguration<Domain.AggregatesModel.SurveyConfigurationAggregate.SurveyConfiguration>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.AggregatesModel.SurveyConfigurationAggregate.SurveyConfiguration> builder)
        {
            builder.HasKey(p => p.SurveyConfigurationId);
            builder.Property(p => p.SurveyConfigurationId).UseHiLo("SurveyConfigurationSequenceId");
            builder.Property(p => p.SurveyConfigurationId).IsRequired();
            builder.Property(p => p.Creator).IsRequired();
            builder.Property(p => p.CreationDate).IsRequired();
            //Enum RelationShip
            builder.Property(p => p.SurveyType).IsRequired().HasConversion(p => p.Value, p => SurveyType.FromValue(p));
            builder.Property(p => p.ImpactRate).IsRequired().HasConversion(p => p.Value, p => ImpactRate.FromValue(p));
            builder.Property(p => p.SamplingMethod).IsRequired().HasConversion(p => p.Value, p => SamplingMethod.FromValue(p));
            

            //builder.Property(p => p.Creator).IsRequired();
            //builder.Property(p => p.CreationDate).IsRequired();

        }
    }
}
