using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Satisfaction.Application.Queries.AssignedChassis;
using Satisfaction.Application.Services;
using Satisfaction.Infrastructure.Persistence;

namespace Satisfaction.Infrastructure.Services
{
    public class AssignedChassisQueryService : IAssignedChassisQueryService
    {
        private readonly ReadDataBase _readDataBase;

        public AssignedChassisQueryService(ReadDataBase readDataBase)
        {
            _readDataBase = readDataBase;
        }

        public Task<List<AssignedChassisInfo>> GetAssignedChassisInfo(int partyId)
        {

            return _readDataBase.AssignedChassisInfos.Where(t => t.PartyId == partyId).AsNoTracking().ToListAsync();
        }
    }
}