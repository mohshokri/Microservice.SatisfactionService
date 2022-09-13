using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Domain.AggregatesModel.SurveyConfigurationAggregate
{
    /// <summary>
    /// روش نمونه برداری
    /// </summary>
    public class SamplingMethod: SmartEnum<SamplingMethod>
    {
        public SamplingMethod() : base(" ", -1)
        {

        }
        public SamplingMethod(string name, int value) : base(name, value)
        {

        }
        public static readonly SamplingMethod Selective = new SamplingMethod("انتخابی", 1);
        public static readonly SamplingMethod AllEmbracing = new SamplingMethod("تمام شمار", 2);
        public static readonly SamplingMethod FormulaBased = new SamplingMethod("بر اساس فرمول", 3);
    }
}
