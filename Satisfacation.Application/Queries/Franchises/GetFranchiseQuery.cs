using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Satisfaction.Application.Queries.Franchises
{
    public class GetFranchiseQuery:IRequest<FranchiseInfoList>
    {

    }
}
