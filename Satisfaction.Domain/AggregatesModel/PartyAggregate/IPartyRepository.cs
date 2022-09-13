  using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Satisfaction.Domain.SeedWork;

namespace Satisfaction.Domain.AggregatesModel.PartyAggregate
{
    public interface IPartyRepository:IRepository<Party>
    {
        public List<Party> GetExpertList(int franchiseId);
    }
}
