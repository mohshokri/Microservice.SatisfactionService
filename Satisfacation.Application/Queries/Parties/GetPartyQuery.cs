using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Satisfaction.Application.Queries.Parties
{
    public class GetPartyQuery:IRequest<PartyInfoList>
    {
        public int FranchiseId { get;set;}
    }
}
