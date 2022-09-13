using System.Collections.Generic;
using System.Threading.Tasks;
using Satisfaction.Application.Queries.AssignedChassis;

namespace Satisfaction.Application.Services
{
    public interface IAssignedChassisQueryService
    {
        Task<List<AssignedChassisInfo>> GetAssignedChassisInfo(int partyId);
    }
}