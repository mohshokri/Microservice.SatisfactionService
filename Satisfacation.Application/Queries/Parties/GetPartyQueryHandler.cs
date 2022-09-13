using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Satisfaction.Domain.AggregatesModel.PartyAggregate;

namespace Satisfaction.Application.Queries.Parties
{
    public class GetPartyQueryHandler : IRequestHandler<GetPartyQuery, PartyInfoList>
    {
        private readonly IPartyRepository _partyRepository;
        public GetPartyQueryHandler(IPartyRepository partyRepository)
        {
            _partyRepository = partyRepository;
        }

        public async Task<PartyInfoList> Handle(GetPartyQuery request, CancellationToken cancellationToken)
        {
            // var roleType = SurveyType.FromValue(createSurveyRequest.SurveyType);

            var partyInfos = _partyRepository.GetExpertList(request.FranchiseId).Select(t => new PartyInfo()
            {
                PartyId = t.PartyId,
                PartyCode = t.PartyCode,
                Name = t.Name,
                Family = t.Family,
                FranchiseId = t.FranchiseId,
                IsActive = t.IsActive,
                Email = t.Email,
                MobileNumber = t.MobileNumber,
                RoleType = t.Roles.Select(t=>t.Value).ToList()
            }).ToList();
            if (!partyInfos.Any())
                throw new Exception("کارشناسی وجود ندارد.");
            return new PartyInfoList { PartyInfos = partyInfos };
        }

    }
}
