using Satisfaction.Domain.AggregatesModel.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Application.Queries.ChassisIncluded
{
    public class ChassisInfo
    {
        public string ChassisNo { get; set; }
        public int DATEDIFF { get; set; }
        //public DateTime Date { get; set; }
        //public DateTime ExitDate { get; set; }
        //public DateTime EXIT_DATE { get; set; }
        //public string modeel { get; set; }
        public string type { get; set; }
        //public string type_id { get; set; }

    }
}
