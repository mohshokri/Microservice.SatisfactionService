using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Satisfaction.Domain.AggregatesModel.MessageAggregate;

namespace Satisfaction.Infrastructure.Persistence.Configurations.MessageConfiguration
{
    public class OutboxConfig : IEntityTypeConfiguration<Outbox>
    {
        public void Configure(EntityTypeBuilder<Outbox> builder)
        {
            builder.HasKey(p => p.OutboxId);
            builder.Property(p => p.OutboxId).IsRequired();
            builder.Property(p => p.ActId).IsRequired();
            builder.Property(p => p.SendType).IsRequired();
            builder.Property(p => p.MobileNumber).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.IsSent).IsRequired();
        }
    }
}
