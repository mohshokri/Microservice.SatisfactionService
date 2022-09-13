using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Satisfaction.Domain.AggregatesModel.SMSAggregate;

namespace Satisfaction.Infrastructure.Persistence.Configurations.MessageConfiguration
{
    public class SendMessageConfig : IEntityTypeConfiguration<SendMessage>
    {
        public void Configure(EntityTypeBuilder<SendMessage> builder)
        {
            builder.HasKey(p => p.SendMessageId);
            builder.Property(p => p.SendMessageId).IsRequired();
            builder.Property(p => p.MessageTemplateId).IsRequired();
            builder.Property(p => p.ActId).IsRequired();
            builder.Property(p => p.CustomizedTextMessage).HasMaxLength(500);
            builder.Property(p => p.SendType).IsRequired();

            builder.HasMany(p => p.MessageTemplates).WithOne(p => p.SendMessage).HasForeignKey(p => p.MessageTemplateId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
