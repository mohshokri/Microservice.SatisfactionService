using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Satisfaction.Application.Commands.SurveyAssignments;
using Satisfaction.Application.ExternalDbConfigurations;
using Satisfaction.Application.Queries.ChassisIncluded;
using Satisfaction.Application.Services;
using Satisfaction.Domain.AggregatesModel.Shared;
using Satisfaction.Domain.AggregatesModel.SurveyAssignmentAggregate;
using Satisfaction.Infrastructure.Persistence;

namespace Satisfaction.Infrastructure.Services
{
    public class ChassisQueryService : IChassisQueryService
    {
        private readonly SatisfactionContext _satisfactionContext;
        private readonly ITimeSettingService _timeSettingService;

        private readonly string _erpConnectionString1;
        private readonly string _erpConnectionString2;
        public ChassisQueryService(SatisfactionContext satisfactionContext, IOptions<MammutERPConfig> settings1, IOptions<ChassisInformationConfig> settings2,/* string erpConnectionString1, string erpConnectionString2,*/ ITimeSettingService timeSettingService)
        {
            _satisfactionContext = satisfactionContext;
            //_erpConnectionString1 = erpConnectionString1;
            //_erpConnectionString2 = erpConnectionString2;

            _erpConnectionString1 = settings1.Value.ConnectionString;
            _erpConnectionString2 = settings2.Value.ConnectionString;

            _timeSettingService = timeSettingService;
        }
        public async Task<int> GetChassisIncludedCountAsync(SurveyType surveyType)
        {
            //int chassisIncluded = 0;

            //if (surveyType == SurveyType.SalesProcess.Value || surveyType == SurveyType.ProductQuality.Value)
            //{
            //    var dbConnection = new SqlConnection(_erpConnectionString2);
            //    var sql = "select * from View_ClaimChassisList_nazarsanji where  DATEDIFF <= @timeSettingValue";
            //    chassisIncluded = dbConnection.QueryAsync(sql, new { surveyType = surveyType }).Result.Count();
            //}

            //if (surveyType == SurveyType.QRSAssistanceService.Value || surveyType == SurveyType.QAfterSalesService.Value || surveyType == SurveyType.QAfterRepairsService.Value)
            //{
            //    var dbConnection = new SqlConnection(_erpConnectionString1);
            //    var sql = "select * from nazarsanji_2 where  DATEDIFF <= @timeSettingValue";
            //    chassisIncluded = dbConnection.QueryAsync(sql, new { surveyType = surveyType }).Result.Count();
            //}

            //return chassisIncluded;

            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<ChassisInfo>> GetChassisIncludedListFromErpAsync(int timeSettingValue, ProductType productType, int assignedChassisCount)
        {
            var dbConnection = new SqlConnection(_erpConnectionString2);
            var productTypeId = productType.Value;
            var sql = "select * from nazarsanji_2 where  DATEDIFF <= @timeSettingValue and type_id=@productTypeId";
            var chassisIncluded = dbConnection.QueryAsync<ChassisInfoFromErp>(sql, new { timeSettingValue, productTypeId }).Result.ToList();

            var assignedList = chassisIncluded.Take(assignedChassisCount).ToList();

            var chassisInfos = chassisIncluded.Select(s => new ChassisInfo()
                {ChassisNo = s.ChassisNo, DATEDIFF = s.DATEDIFF, type = s.type}).ToList();

            return chassisInfos;
        }

        public async Task<IEnumerable<ChassisInfo>> GetChassisIncludedListFromChassisInformationAsync(int timeSettingValue, ProductType productType, int assignedChassisCount)
        {
            var dbConnection = new SqlConnection(_erpConnectionString2);

            int productTypeId = productType.Value;
            var sql = "select * from View_ClaimChassisList_nazarsanji where  DATEDIFF <= @timeSettingValue and type_id=@productTypeId";
            var chassisIncluded = dbConnection.QueryAsync<ChassisInfoFromChassisInformation>(sql, new {  timeSettingValue, productTypeId }).Result.ToList();


            var chassisInfos = chassisIncluded.Select(s => new ChassisInfo()
                { ChassisNo = s.ChassisNo, DATEDIFF = s.DATEDIFF, type = s.type }).ToList();

            return chassisInfos;
        }
    }
}