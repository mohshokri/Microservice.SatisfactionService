using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Domain.AggregatesModel.SurveyConfigurationAggregate
{
    /// <summary>
    /// نرخ تأثیر
    /// </summary>
    public class ImpactRate: SmartEnum<ImpactRate>
    {
        public ImpactRate() : base(" ", -1)
        {

        }
        public ImpactRate(string name, int value) : base(name, value)
        {

        }
        public static readonly ImpactRate TenPercent = new ImpactRate("10%", 1);
        public static readonly ImpactRate TwentyPercent = new ImpactRate("20%", 2);
        public static readonly ImpactRate ThirtyPercent = new ImpactRate("30%", 3);
        public static readonly ImpactRate FortyPercent = new ImpactRate("40%", 4);
        public static readonly ImpactRate FiftyPercent = new ImpactRate("50%", 5);
        public static readonly ImpactRate SixtyPercent = new ImpactRate("60%", 6);
        public static readonly ImpactRate SeventyPercent = new ImpactRate("70%", 7);
        public static readonly ImpactRate EightyPercent = new ImpactRate("80%", 8);
        public static readonly ImpactRate NinetyPercent = new ImpactRate("90%", 9);
        public static readonly ImpactRate HundredPercent = new ImpactRate("100%", 10);
        public static readonly ImpactRate Trimester = new ImpactRate("سه ماهه", 11);
        public static readonly ImpactRate OneMonth = new ImpactRate("یک ماهه", 12);
    }
}
