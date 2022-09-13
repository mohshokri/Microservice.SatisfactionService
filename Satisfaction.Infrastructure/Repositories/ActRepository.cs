using System.Threading.Tasks;
using Satisfaction.Domain.AggregatesModel.ActAggregate;
using Satisfaction.Infrastructure.Persistence;

namespace Satisfaction.Infrastructure.Repositories
{
    public class ActRepository:IActRepository
    {
        private readonly SatisfactionContext _context;

        public ActRepository(SatisfactionContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Act act)
        {
            await _context.Acts.AddAsync(act);
        }
    }
}