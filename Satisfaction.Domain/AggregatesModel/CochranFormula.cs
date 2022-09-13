using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Domain.AggregatesModel.SurveyConfigurationAggregate
{
    /// <summary>
    /// فرمول کوکران
    /// </summary>
    public class CochranFormula
    {
        public int CochranFormulaId { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        //سه ماهه
        public int Trimester { get; set; }
        //یک ماهه
        public int OneMonth { get; set; }
    }
}
