using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using Satisfaction.Domain.AggregatesModel.Shared;

namespace Satisfaction.Infrastructure.Persistence.Configurations.SurveyConfiguration
{
    public class SurveyConfig : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.HasKey(p => p.SurveyId);
            builder.Property(p => p.SurveyId).UseHiLo("SurveySequenceId");
            builder.Property(p => p.SurveyId).IsRequired();
            builder.Property(p => p.PartyId).IsRequired();
            builder.Property(p => p.SurveyCode).IsRequired().HasMaxLength(50);
            //Enum RelationShip
            builder.Property(p => p.SurveyType).IsRequired().HasConversion(p => p.Value, p => SurveyType.FromValue(p));

            builder.Property(p => p.SurveyTitle).IsRequired().HasMaxLength(200);
            builder.Ignore(p => p.DomainEvents);
            builder.Property(p => p.IsActive).IsRequired();
            builder.OwnsOne(p => p.SurveyImage);
            builder.OwnsOne(p => p.ActivationRange);
            builder.Property(p => p.Creator).IsRequired();
            builder.Property(p => p.CreationDate).IsRequired();

            builder.HasMany(p => p.Questions).WithOne().HasForeignKey(p => p.SurveyId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.SurveyScores).WithOne().HasForeignKey(p => p.SurveyId).OnDelete(DeleteBehavior.Cascade);

            //builder.HasMany(p => p.CustomerValidationRules).WithOne().HasForeignKey("SaleCodeId");

        }
    }
}
