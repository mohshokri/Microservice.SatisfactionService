using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.Extensions.Options;
using Satisfaction.Application.ExternalDbConfigurations;
using Satisfaction.Domain.AggregatesModel.Shared;
using Satisfaction.Domain.AggregatesModel.TimeSettingAggregate;

namespace Satisfaction.Application.Queries.ChassisIncluded
{
    public class GetChassisIncludedQueryHandler : IRequestHandler<GetChassisIncludedQuery, int>
    {
        private readonly ITimeSettingRepository _timeSettingRepository;

        private readonly string _erpConnectionString1;
        private readonly string _erpConnectionString2;

        public GetChassisIncludedQueryHandler(ITimeSettingRepository timeSettingRepository, IOptions<MammutERPConfig> settings1, IOptions<ChassisInformationConfig> settings2)
        {
            _timeSettingRepository = timeSettingRepository;
            _erpConnectionString1 = settings1.Value.ConnectionString;
            _erpConnectionString2 = settings2.Value.ConnectionString;
        }
        public async Task<int> Handle(GetChassisIncludedQuery request, CancellationToken cancellationToken)
        {
            var surveyType = request.SurveyType;
            if(_timeSettingRepository.Get(surveyType) == null)
                throw new Exception("تنظیمات یافت نشد");
            var timeSettingValue = _timeSettingRepository.Get(surveyType).Value;
            int count = 0;
            if (surveyType == SurveyType.SalesProcess.Value || surveyType == SurveyType.ProductQuality.Value)
            {
                var dbConnection = new SqlConnection(_erpConnectionString2);
                var sql = "select * from View_ClaimChassisList_nazarsanji where  DATEDIFF <= @timeSettingValue";

                count = dbConnection.QueryAsync(sql, new { timeSettingValue = timeSettingValue }).Result.Count();
            }

            if (surveyType == SurveyType.QRSAssistanceService.Value || surveyType == SurveyType.QAfterSalesService.Value || surveyType == SurveyType.QAfterRepairsService.Value)
            {
                var dbConnection = new SqlConnection(_erpConnectionString1);
                var sql = "select * from nazarsanji_2 where  DATEDIFF <= @timeSettingValue";
                count = dbConnection.QueryAsync(sql, new { timeSettingValue = timeSettingValue }).Result.Count();
            }

            return count;
        }
    }
}
