using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Options;
using Satisfaction.Application.ExternalDbConfigurations;
using Satisfaction.Application.Queries.ChassisIncluded;
using Satisfaction.Application.Services;
using Satisfaction.Domain.AggregatesModel.Shared;
using Satisfaction.Domain.AggregatesModel.SurveyAssignmentAggregate;
using Satisfaction.Domain.AggregatesModel.SurveyConfigurationAggregate;


namespace Satisfaction.Application.Commands.SurveyAssignments
{
    public class AssignChassisCommandHandler : AsyncRequestHandler<AssignChassisCommand>
    {
        private readonly IChassisQueryService _chassisQueryService;
        private readonly ITimeSettingService _timeSettingService;
        private readonly ISurveyConfigurationRepository _configurationRepository;

        private readonly ISurveyAssignmentRepository _surveyAssignmentRepository;

        private readonly string _erpConnectionString1;
        private readonly string _erpConnectionString2;

        public AssignChassisCommandHandler(ISurveyAssignmentRepository surveyAssignmentRepository, IOptions<MammutERPConfig> settings1, 
            IOptions<ChassisInformationConfig> settings2, IChassisQueryService chassisQueryService, ITimeSettingService timeSettingService, ISurveyConfigurationRepository configurationRepository)
        {
            _surveyAssignmentRepository = surveyAssignmentRepository;
            _chassisQueryService = chassisQueryService;
            _timeSettingService = timeSettingService;
            _erpConnectionString1 = settings1.Value.ConnectionString;
            _erpConnectionString2 = settings2.Value.ConnectionString;
            _configurationRepository = configurationRepository;
        }
        protected override async Task Handle(AssignChassisCommand request, CancellationToken cancellationToken)
        {
           // var assignedChassis = request.AssignedChassis.Select(t => new AssignedChassis(t.SurveyAssignmentId, t.ChassisNumber)).ToList();

            //var surveyType = request.SurveyType;
            //var surveyTypeEnume = SurveyType.FromValue(surveyType);

            var configuration = _configurationRepository.GetAsync(request.SurveyConfigurationId).Result;
            var surveyType = configuration.SurveyType;
            if (_timeSettingService.GetTimeSettingAsync(configuration.SurveyType.Value) == null)
                throw new Exception("تنظیمات یافت نشد");

            var timeSettingValue = await _timeSettingService.GetTimeSettingAsync(surveyType.Value);

            var chassisInfos = new List<ChassisInfo>();

            if (surveyType == SurveyType.SalesProcess.Value || surveyType == SurveyType.ProductQuality.Value)
            {
              // request.ChassisIncluded= await _chassisQueryService.GetChassisIncludedCountAsync(surveyType)
                chassisInfos = (await _chassisQueryService.GetChassisIncludedListFromChassisInformationAsync(timeSettingValue,
                        request.ProductType, request.AssignedChassisCount)).ToList();
            }
            if (surveyType == SurveyType.QRSAssistanceService.Value || surveyType == SurveyType.QAfterSalesService.Value || surveyType == SurveyType.QAfterRepairsService.Value)
            {
                chassisInfos = (await _chassisQueryService.GetChassisIncludedListFromErpAsync(timeSettingValue,
                        request.ProductType, request.AssignedChassisCount)).ToList();
            }

            //var Chassislist = new List<Domain.AggregatesModel.SurveyAssignmentAggregate.AssignedChassis>();

            //Chassislist = assignedChassis.Select(t => new Domain.AggregatesModel.SurveyAssignmentAggregate.AssignedChassis
            //{
            //    ChassisNumber = t.ChassisNumber,

            //}).ToList();
            var chassisList= chassisInfos.Select(s=> new AssignedChassis
            {
                ChassisNumber = s.ChassisNo,
            }).ToList();

            var surveyAssignment = new SurveyAssignment(request.PartyId, request.FranchiseId, request.ProductType, request.EndDate, request.SurveyConfigurationId, chassisList);

            await _surveyAssignmentRepository.AddAsync(surveyAssignment);
        }
    }
}
