using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Application.Queries.Franchises
{
    public class FranchiseInfo
    {
        public int FranchiseId { get; set; }
        public int? CompanyId { get; set; }
        public int BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchTitle { get; set; }
        public bool IsActive { get; set; }
    }
}
