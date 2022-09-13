using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Satisfaction.Application.Queries.AssignedChassis;
using Satisfaction.Application.Queries.CallHistory;

namespace Satisfaction.Infrastructure.Persistence
{
    public class ReadDataBase : DbContext
    {
        public ReadDataBase(DbContextOptions<ReadDataBase> options) : base(options)
        {

        }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<AssignedChassisInfo> AssignedChassisInfos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContactInfo>(e =>
            {
                e.HasNoKey();
                e.ToView("View_ContactInfos");
            });

            modelBuilder.Entity<AssignedChassisInfo>(e =>
            {
                e.HasNoKey();
                e.Ignore(t => t.SurveyTitle);
                e.ToView("View_AssignedChassisInfos");
            });
        }
    }
}