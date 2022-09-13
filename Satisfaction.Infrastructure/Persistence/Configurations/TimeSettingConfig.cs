using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Satisfaction.Domain.AggregatesModel;
using Satisfaction.Domain.AggregatesModel.TimeSettingAggregate;

namespace Satisfaction.Infrastructure.Persistence.Configurations
{
    public class TimeSettingConfig : IEntityTypeConfiguration<TimeSetting>
    {
        public void Configure(EntityTypeBuilder<TimeSetting> builder)
        {
            builder.HasKey(p => p.TimeSettingId);
            builder.Property(p => p.TimeSettingId).IsRequired();
            builder.Property(p => p.Key).IsRequired();
            builder.Property(p => p.Value).IsRequired();
        }
    }
}
