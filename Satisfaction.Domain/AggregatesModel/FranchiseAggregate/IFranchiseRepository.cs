using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Satisfaction.Domain.AggregatesModel.PartyAggregate;
using Satisfaction.Domain.SeedWork;

namespace Satisfaction.Domain.AggregatesModel.FranchiseAggregate
{
    public interface IFranchiseRepository:IRepository<Franchise>
    {
        //public Task<List<Franchise>> GetFranchiseList();
        public List<Franchise> GetFranchiseList();
    }
}
