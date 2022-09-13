using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Satisfaction.Domain.AggregatesModel.SurveyAssignmentAggregate;

namespace Satisfaction.Infrastructure.Persistence.Configurations.SurveyAssignmentConfiguration
{
    public class SurveyAssignmentConfig : IEntityTypeConfiguration<SurveyAssignment>
    {
        public void Configure(EntityTypeBuilder<SurveyAssignment> builder)
        {
            builder.HasKey(p => p.SurveyAssignmentId);
            builder.Property(p => p.SurveyAssignmentId).UseHiLo("SurveyAssignmentSequenceId");

            builder.Property(p => p.SurveyConfigurationId).IsRequired();
            builder.Property(p => p.PartyId).IsRequired();
            builder.Property(p => p.FranchiseId).IsRequired();
            builder.Property(p => p.ProductType).IsRequired().HasConversion(p => p.Value, p => ProductType.FromValue(p));
            builder.Property(p => p.EndDate).IsRequired();

            builder.HasOne(p => p.Party).WithMany(p => p.SurveyAssignments).HasForeignKey(p => p.PartyId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
