using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Satisfaction.Domain.AggregatesModel.SurveyConfigurationAggregate;

namespace Satisfaction.Infrastructure.Persistence.Configurations.SurveyConfigurationConfiguration
{
    public class CochranFormulaConfig : IEntityTypeConfiguration<CochranFormula>
    {
        public void Configure(EntityTypeBuilder<CochranFormula> builder)
        {
            builder.HasKey(p => p.CochranFormulaId);
            builder.Property(p => p.CochranFormulaId).IsRequired();
            builder.Property(p => p.Min).IsRequired();
            builder.Property(p => p.Max).IsRequired();
            builder.Property(p => p.Trimester).IsRequired();
            builder.Property(p => p.OneMonth).IsRequired();
        }
    }
}
