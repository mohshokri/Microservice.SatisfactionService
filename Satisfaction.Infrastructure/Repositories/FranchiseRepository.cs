using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Satisfaction.Domain.AggregatesModel.FranchiseAggregate;
using Satisfaction.Domain.AggregatesModel.PartyAggregate;
using Satisfaction.Infrastructure.Persistence;

namespace Satisfaction.Infrastructure.Repositories
{
    public class FranchiseRepository:IFranchiseRepository
    {
        private readonly SatisfactionContext _satisfactionContext;

        public FranchiseRepository(SatisfactionContext satisfactionContext)
        {
            _satisfactionContext = satisfactionContext;
        }

        //public async Task<Franchise> GetFranchiseList()
        //{
        //    throw await _satisfactionContext.Franchises.AsQueryable().ToListAsync();
        //}
        public List<Franchise> GetFranchiseList()
        {
            return _satisfactionContext.Franchises.AsQueryable().ToList();
        }
    }
}
