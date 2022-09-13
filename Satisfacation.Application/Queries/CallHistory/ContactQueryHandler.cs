using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Satisfaction.Application.Services;

namespace Satisfaction.Application.Queries.CallHistory
{
    public class ContactQueryHandler:IRequestHandler<ContactQuery,List<ContactInfo>>
    {
        private readonly IContactQueryService _contactQueryService;

        public ContactQueryHandler(IContactQueryService contactQueryService)
        {
            _contactQueryService = contactQueryService;
        }

        public async Task<List<ContactInfo>> Handle(ContactQuery request, CancellationToken cancellationToken)
        {
            return await _contactQueryService.GetContactInfo(request.ChassisNumber);
        }
    }
}