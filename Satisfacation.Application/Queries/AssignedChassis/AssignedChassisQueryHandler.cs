using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Satisfaction.Application.Services;

namespace Satisfaction.Application.Queries.AssignedChassis
{
    public class AssignedChassisQueryHandler : IRequestHandler<AssignedChassisQuery, List<AssignedChassisInfo>>
    {
        private readonly IAssignedChassisQueryService _assignedChassisQueryService;

        public AssignedChassisQueryHandler(IAssignedChassisQueryService assignedChassisQueryService)
        {
            _assignedChassisQueryService = assignedChassisQueryService;
        }

        public async Task<List<AssignedChassisInfo>> Handle(AssignedChassisQuery request, CancellationToken cancellationToken)
        {
            return await _assignedChassisQueryService.GetAssignedChassisInfo(request.PartyId);
        }
    }
}