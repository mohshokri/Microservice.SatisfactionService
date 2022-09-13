using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Satisfaction.Domain.AggregatesModel.SurveyAssignmentAggregate;

namespace Satisfaction.Infrastructure.Persistence.Configurations.SurveyAssignmentConfiguration
{
    public class AssignedChassisConfig : IEntityTypeConfiguration<AssignedChassis>
    {
        public void Configure(EntityTypeBuilder<AssignedChassis> builder)
        {
            builder.HasKey(p => p.AssignedChassisId);
            builder.Property(p => p.AssignedChassisId).IsRequired();
            builder.Property(p => p.SurveyAssignmentId).IsRequired();
            builder.Property(p => p.ChassisNumber).IsRequired();

            builder.HasOne(p => p.SurveyAssignment)
                .WithMany(p => p.AssignedChassis).HasForeignKey(p => p.SurveyAssignmentId).OnDelete(DeleteBehavior.Cascade);


        }
    }
}
