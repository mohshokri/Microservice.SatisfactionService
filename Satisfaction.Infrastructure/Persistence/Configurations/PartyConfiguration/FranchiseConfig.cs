using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Satisfaction.Domain.AggregatesModel.PartyAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Infrastructure.Persistence.Configurations.PartyConfiguration
{
    public class FranchiseConfig : IEntityTypeConfiguration<Franchise>
    {
        public void Configure(EntityTypeBuilder<Franchise> builder)
        {
            builder.HasKey(p => p.FranchiseId);
            builder.Property(p => p.FranchiseId).ValueGeneratedNever().IsRequired();
            builder.Property(p => p.BranchId).IsRequired();
            builder.Property(p => p.BranchCode).IsRequired();

            builder.HasMany(p => p.Parties).WithOne(p => p.Franchise).HasForeignKey(p => p.FranchiseId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
