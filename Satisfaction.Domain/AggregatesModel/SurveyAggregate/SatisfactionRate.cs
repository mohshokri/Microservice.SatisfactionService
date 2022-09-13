using System;
using System.Collections.Generic;
using System.Text;
using Ardalis.SmartEnum;

namespace Satisfaction.Domain.AggregatesModel.SurveyAggregate
{
    public class SatisfactionRate : SmartEnum<SatisfactionRate>
    {
        //خیلی ناراضی
        public static readonly SatisfactionRate VeryDissatisfied = new SatisfactionRate("VeryDissatisfied", 1);
        //ناراضی
        public static readonly SatisfactionRate Dissatisfied = new SatisfactionRate("Dissatisfied", 2);
        //متوسط
        public static readonly SatisfactionRate Neutral = new SatisfactionRate("Neutral", 3);
        //راضی
        public static readonly SatisfactionRate Satisfied = new SatisfactionRate("Satisfied", 4);
        //خیلی راضی
        public static readonly SatisfactionRate VerySatisfied = new SatisfactionRate("VerySatisfied", 5);

        public SatisfactionRate(string name, int value) : base(name, value)
        {
        }

    }
}
