using System.Collections.Generic;
using System.Threading.Tasks;
using Satisfaction.Application.Queries.CallHistory;

namespace Satisfaction.Application.Services
{
    public interface IContactQueryService
    {
        Task<List<ContactInfo>> GetContactInfo(string chassisNumber);
    }
}