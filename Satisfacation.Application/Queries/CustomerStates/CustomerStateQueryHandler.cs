using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Satisfaction.Domain.AggregatesModel.ActAggregate;

namespace Satisfaction.Application.Queries.CustomerStates
{
    public class CustomerStateQueryHandler : IRequestHandler<CustomerStateQuery, List<CustomerStateInfo>>
    {
        public async Task<List<CustomerStateInfo>> Handle(CustomerStateQuery request,
            CancellationToken cancellationToken)
        {
            var customerState = CustomerState.List.ToList();
            return customerState.Select(t => new CustomerStateInfo()
            {
                Id = t.Value,
                Name = t.Name
            }).ToList();
        }
    }
}