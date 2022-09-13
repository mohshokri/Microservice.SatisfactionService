using System.Threading.Tasks;
using Satisfaction.Domain.SeedWork;

namespace Satisfaction.Domain.AggregatesModel.ActAggregate
{
    public interface IActRepository:IRepository<Act>
    {
        Task AddAsync(Act act);

    }
}