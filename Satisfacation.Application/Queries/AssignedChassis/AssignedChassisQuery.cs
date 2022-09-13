using System.Collections.Generic;
using MediatR;

namespace Satisfaction.Application.Queries.AssignedChassis
{
    public class AssignedChassisQuery : IRequest<List<AssignedChassisInfo>>
    {
        public int PartyId { get; set; }
    }
}