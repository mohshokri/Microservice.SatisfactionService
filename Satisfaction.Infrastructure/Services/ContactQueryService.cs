using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Satisfaction.Application.Queries.CallHistory;
using Satisfaction.Application.Services;
using Satisfaction.Infrastructure.Persistence;

namespace Satisfaction.Infrastructure.Services
{
    public class ContactQueryService : IContactQueryService
    {
        private readonly ReadDataBase _readDataBase;

        public ContactQueryService(ReadDataBase readDataBase)
        {
            _readDataBase = readDataBase;
        }

        public async Task<List<ContactInfo>> GetContactInfo(string chassisNumber)
        {
            return await _readDataBase.ContactInfos.Where(t => t.ChassisNumber == chassisNumber).ToListAsync();

            //throw new System.NotImplementedException();
        }
    }
}