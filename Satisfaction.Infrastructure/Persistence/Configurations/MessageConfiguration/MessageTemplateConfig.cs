using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Satisfaction.Domain.AggregatesModel.SMSAggregate;

namespace Satisfaction.Infrastructure.Persistence.Configurations.MessageConfiguration
{
    public class MessageTemplateConfig : IEntityTypeConfiguration<MessageTemplate>
    {
        public void Configure(EntityTypeBuilder<MessageTemplate> builder)
        {
            builder.HasKey(p => p.MessageTemplateId);
            builder.Property(p => p.MessageTemplateId).IsRequired();
            builder.Property(p => p.TemplateTitle).IsRequired();
            builder.Property(p => p.TemplateText).IsRequired();
            builder.Property(p => p.IsFix).HasDefaultValue(true);

        }
    }
}
