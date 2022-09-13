using Satisfaction.Domain.AggregatesModel.PartyAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Application.Queries.Parties
{
    public class PartyInfo
    {
        public int PartyId { get; set; }
        public string PartyCode { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public int FranchiseId { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public List<int> RoleType { get; set; }

    }
}
