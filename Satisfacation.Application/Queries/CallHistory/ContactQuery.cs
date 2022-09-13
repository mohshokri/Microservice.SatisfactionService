using System.Collections.Generic;
using MediatR;

namespace Satisfaction.Application.Queries.CallHistory
{
    public class ContactQuery : IRequest<List<ContactInfo>>
    {
        public string ChassisNumber { get; set; }
    }
}