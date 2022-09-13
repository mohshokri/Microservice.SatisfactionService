using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Satisfaction.Domain.AggregatesModel.ActAggregate;
using Satisfaction.Domain.AggregatesModel.Shared;

namespace Satisfaction.Infrastructure.Persistence.Configurations.ActConfiguration
{
    public class ActConfig : IEntityTypeConfiguration<Act>
    {
        public void Configure(EntityTypeBuilder<Act> builder)
        {
            builder.HasKey(p => p.ActId);
            builder.Property(p => p.ActId).IsRequired();
            builder.Property(p => p.AssignedChassisId).IsRequired();
            builder.Property(p => p.IsSuccessCall).IsRequired();
            builder.Property(p => p.IsSurvey).IsRequired();
            builder.Property(p => p.ActDate).IsRequired();
            builder.Property(p => p.AlarmDate).IsRequired();
            builder.Property(p => p.AlarmTime).IsRequired();
            builder.Property(p => p.CustomerState).IsRequired().HasConversion(p => p.Value, p => CustomerState.FromValue(p));
            builder.Property(p => p.ContactType).IsRequired().HasConversion(p => p.Value, p => ContactType.FromValue(p));
            builder.Property(p => p.AlarmDescription).HasMaxLength(500);
            builder.Property(p => p.CrmSupervisorDescription).HasMaxLength(500);
            builder.Property(p => p.Creator).IsRequired();
            builder.Property(p => p.CreationDate).IsRequired();

            builder.HasOne(p => p.AssignedChassis).WithMany(p => p.Acts).HasForeignKey(p => p.AssignedChassisId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.SurveyAnswer).WithMany().HasForeignKey(p => p.AnswerId);
        }
    }
}
