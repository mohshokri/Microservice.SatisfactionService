using System;
using System.Collections.Generic;
using System.Text;
using Satisfaction.Domain.SeedWork;

namespace Satisfaction.Domain.AggregatesModel.PartyAggregate
{
    public class Franchise: Entity, IAggregateRoot
    {
        public Franchise()
        {
                
        }
        public int FranchiseId { get; set; }
        public int? CompanyId { get; set; }
        public int BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchTitle { get; set; }
        public bool IsActive { get; set; }

        public List<Party> Parties { get; set; }
    }
}
