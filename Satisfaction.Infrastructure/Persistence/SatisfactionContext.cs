using Microsoft.EntityFrameworkCore;
using Satisfaction.Domain.AggregatesModel;
using Satisfaction.Domain.AggregatesModel.ActAggregate;
using Satisfaction.Domain.AggregatesModel.MessageAggregate;
using Satisfaction.Domain.AggregatesModel.PartyAggregate;
using Satisfaction.Domain.AggregatesModel.SMSAggregate;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate;
using Satisfaction.Domain.AggregatesModel.SurveyAssignmentAggregate;
using Satisfaction.Domain.AggregatesModel.SurveyConfigurationAggregate;
using Satisfaction.Domain.SeedWork;
using Satisfaction.Infrastructure.Persistence.Configurations;
using Satisfaction.Infrastructure.Persistence.Configurations.ActConfiguration;
using Satisfaction.Infrastructure.Persistence.Configurations.MessageConfiguration;
using Satisfaction.Infrastructure.Persistence.Configurations.PartyConfiguration;
using Satisfaction.Infrastructure.Persistence.Configurations.SurveyAssignmentConfiguration;
using Satisfaction.Infrastructure.Persistence.Configurations.SurveyConfiguration;
using Satisfaction.Infrastructure.Persistence.Configurations.SurveyConfigurationConfiguration;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using Satisfaction.Domain.AggregatesModel.SurveyConfigurationAggregate;
using Satisfaction.Domain.AggregatesModel.TimeSettingAggregate;

namespace Satisfaction.Infrastructure.Persistence
{
    public class SatisfactionContext : DbContext, IUnitOfWork
    {
        public SatisfactionContext(DbContextOptions<SatisfactionContext> options) : base(options)
        {

        }

        public DbSet<Party> Parties { get; set; }
        public DbSet<Franchise> Franchises { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyQuestion> Questions { get; set; }
        public DbSet<SurveyQuestionItem> QuestionItems { get; set; }
        public DbSet<SurveyAnswer> Answers { get; set; }
        public DbSet<AnswerQuestionItem> AnswerQuestionItems { get; set; }
        public DbSet<SurveyScore> SurveyScores { get; set; }
        public DbSet<SurveyConfiguration> SurveyConfigurations { get; set; }
       
        //public DbSet<CochranFormula> CochranFormulas { get; set; }
        public DbSet<SurveyAssignment> SurveyAssignments { get; set; }
        public DbSet<AssignedChassis> AssignedChassis { get; set; }
        public DbSet<Act> Acts { get; set; }
        public DbSet<TimeSetting> TimeSettings { get; set; }
        public DbSet<MessageTemplate> MessageTemplates { get; set; }
        public DbSet<SendMessage> SendMessages { get; set; }
        public DbSet<Outbox> OutBoxes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            //modelBuilder.ApplyConfiguration(new PartyConfig());
            //modelBuilder.ApplyConfiguration(new FranchiseConfig());
            //modelBuilder.ApplyConfiguration(new SurveyConfig());
            //modelBuilder.ApplyConfiguration(new SurveyQuestionConfig());
            //modelBuilder.ApplyConfiguration(new SurveyQuestionItemConfig());
            //modelBuilder.ApplyConfiguration(new SurveyAnswerConfig());
            //modelBuilder.ApplyConfiguration(new SurveyScoreConfig());
            //modelBuilder.ApplyConfiguration(new SurveyConfigurationConfig());
            //modelBuilder.ApplyConfiguration(new ImpactRateConfig());
            //modelBuilder.ApplyConfiguration(new SamplingMethodConfig());
            //modelBuilder.ApplyConfiguration(new CochranFormulaConfig());
            //modelBuilder.ApplyConfiguration(new SurveyAssignmentConfig());
            //modelBuilder.ApplyConfiguration(new AssignedChassisConfig());
            //modelBuilder.ApplyConfiguration(new ActConfig());
            //modelBuilder.ApplyConfiguration(new TimeSettingConfig());
            //modelBuilder.ApplyConfiguration(new MessageTemplateConfig());
            //modelBuilder.ApplyConfiguration(new SendMessageConfig());
            //modelBuilder.ApplyConfiguration(new OutboxConfig());


        }
    }
}
