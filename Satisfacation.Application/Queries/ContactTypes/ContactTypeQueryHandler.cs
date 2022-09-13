using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Satisfaction.Domain.AggregatesModel.ActAggregate;

namespace Satisfaction.Application.Queries.ContactTypes
{
    public class ContactTypeQueryHandler : IRequestHandler<ContactTypeQuery, List<ContactTypeInfo>>
    {
        public async Task<List<ContactTypeInfo>> Handle(ContactTypeQuery request, CancellationToken cancellationToken)
        {
            var contactType = ContactType.List.ToList();
            return contactType.Select(t => new ContactTypeInfo()
            {
                Id = t.Value,
                Name = t.Name
            }).ToList();
        }
    }
}