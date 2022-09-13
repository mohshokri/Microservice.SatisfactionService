using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Domain.AggregatesModel.Shared
{
    public class SurveyType : SmartEnum<SurveyType>
    {
        public SurveyType() : base(" ", -1)
        {

        }
        public SurveyType(string name, int value) : base(name, value)
        {
        }
        public static readonly SurveyType SalesProcess = new SurveyType("فرآیند فروش", 1);
        public static readonly SurveyType ProductQuality = new SurveyType("کیفیت محصول", 2);
        public static readonly SurveyType QRSAssistanceService = new SurveyType("کیفیت خدمات امداد جاده", 3);
        public static readonly SurveyType QAfterSalesService = new SurveyType("کیفیت خدمات پس از فروش", 4);
        public static readonly SurveyType QAfterRepairsService = new SurveyType("کیفیت خدمات بعد از انجام تعمیرات", 5);
    }
}
