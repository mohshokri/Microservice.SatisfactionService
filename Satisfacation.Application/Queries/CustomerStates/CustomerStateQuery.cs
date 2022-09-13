using System.Collections.Generic;
using MediatR;

namespace Satisfaction.Application.Queries.CustomerStates
{
    public class CustomerStateQuery:IRequest<List<CustomerStateInfo>>
    {
        
    }
}