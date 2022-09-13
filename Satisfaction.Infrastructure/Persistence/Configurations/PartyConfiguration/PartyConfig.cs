using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Satisfaction.Domain.AggregatesModel.PartyAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Satisfaction.Infrastructure.Persistence.Configurations.PartyConfiguration
{
    public class PartyConfig : IEntityTypeConfiguration<Party>
    {

        public void Configure(EntityTypeBuilder<Party> builder)
        {
            var xx = string.Join(',', new List<string>());
            builder.HasKey(p => p.PartyId);
            builder.Property(p => p.PartyId).ValueGeneratedNever().IsRequired();
            builder.Property(p => p.PartyCode).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Family).IsRequired();
            builder.Property(p => p.FranchiseId).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            //builder.Property(p => p.RoleType).IsRequired().HasConversion(p => p.Value, p => RoleType.FromValue(p));

            _ = builder.Property(p => p.Roles).HasConversion(
                p => string.Join(',', p.Select(s => s.Value.ToString()).ToList()),
                p => ConvertBackRoleTypes(p));

            builder.Property(p => p.Creator).IsRequired();
            builder.Property(p => p.CreationDate).IsRequired();

        }

        private static List<RoleType> ConvertBackRoleTypes(string p)
        {
            var parts = p.Split(',');
            var roles = parts.Select(s => RoleType.FromValue(int.Parse(s)));
            return roles.ToList();
        }
    }
}
