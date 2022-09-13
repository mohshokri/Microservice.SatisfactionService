using System;
using System.Reflection;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Satisfaction.Application.Behaviors;
using Satisfaction.Application.Commands.Surveys;
using Satisfaction.Application.ExternalDbConfigurations;
using Satisfaction.Application.Queries.Surveys;
using Satisfaction.Application.Services;
using Satisfaction.Domain.AggregatesModel.ActAggregate;
using Satisfaction.Domain.AggregatesModel.FranchiseAggregate;
using Satisfaction.Domain.AggregatesModel.PartyAggregate;
using Satisfaction.Domain.AggregatesModel.SurveyAggregate;
using Satisfaction.Domain.AggregatesModel.SurveyAssignmentAggregate;
using Satisfaction.Domain.AggregatesModel.SurveyConfigurationAggregate;
using Satisfaction.Domain.AggregatesModel.TimeSettingAggregate;
using Satisfaction.Domain.SeedWork;
using Satisfaction.Infrastructure;
using Satisfaction.Infrastructure.Persistence;
using Satisfaction.Infrastructure.Repositories;
using Satisfaction.Infrastructure.Services;

namespace Satisfaction.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //MediatR
            //services.AddMediatR(typeof(CreateSurveyCommand).Assembly);
            //services.AddMediatR(typeof(Startup));


            //DbContext
            services.AddDbContext<SatisfactionContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionString"],
                    sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    });
            });
            //ReadDatabase
            services.AddDbContext<ReadDataBase>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionString"],
                    sqlOptions =>
                    {
                        //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    });

            });


            services.AddMediatR(typeof(CreateSurveyCommand).Assembly)

               .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>))
               .AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkPipelineBehavior<,>));          

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ISurveyQueryService, SurveyQueryService>();

            //AutoMapper
            services.AddAutoMapper(typeof(Startup));

            //Getting Services from ExternalDatabase
            services.Configure<MammutERPConfig>(Configuration.GetSection("MammutERPConfig"));
            services.Configure<ChassisInformationConfig>(Configuration.GetSection("ChassisInformationConfig"));


            //Fluent Validation
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            services.AddMvc().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddTransient<ISurveyRepository, SurveyRepository>();
            services.AddTransient<ISurveyConfigurationRepository, SurveyConfigurationRepository>();
            services.AddTransient<ITimeSettingRepository, TimeSettingRepository>();
            services.AddTransient<IPartyRepository, PartyRepository>();
            services.AddTransient<IFranchiseRepository, FranchiseRepository>();
            services.AddTransient<ISurveyAssignmentRepository, SurveyAssignmentRepository>();
            services.AddTransient<IChassisQueryService, ChassisQueryService>();
            services.AddTransient<ITimeSettingService, TimeSettingService>();
            services.AddTransient<IActRepository, ActRepository>();
            services.AddTransient<ISurveyTitleQueryService, SurveyTitleQueryService>();
            services.AddTransient<ISurveyQuestionQueryService, SurveyQuestionQueryService>();
            services.AddTransient<ISurveyQuestionRepository, SurveyQuestionRepository>();
            services.AddTransient<IContactQueryService, ContactQueryService>();
            services.AddTransient<IAssignedChassisQueryService, AssignedChassisQueryService>();


            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });



            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Swagger for UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
