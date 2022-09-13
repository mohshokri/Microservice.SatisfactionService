using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Satisfaction.Domain.AggregatesModel.PartyAggregate;
using Satisfaction.Infrastructure.Persistence;

namespace Satisfaction.Infrastructure.Repositories
{
    public class PartyRepository : IPartyRepository
    {
        private readonly SatisfactionContext _satisfactionContext;

        public PartyRepository(SatisfactionContext satisfactionContext)
        {
            _satisfactionContext = satisfactionContext;
        }

        public List<Party> GetExpertList(int franchiseId)
        {
            //return _satisfactionContext.Parties.Where(t => t.FranchiseId == franchiseId
            //                                             && t.Roles.Select(t => t.Value).ToList().Contains(RoleType.Expert)).ToList();

            return _satisfactionContext.Parties.AsEnumerable().Where(t => t.FranchiseId == franchiseId
                                                                           && t.Roles.Select(t => t.Value).Contains(RoleType.Expert)).ToList();

        }


    }
}
