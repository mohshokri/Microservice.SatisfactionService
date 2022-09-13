using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Satisfaction.Domain.AggregatesModel.FranchiseAggregate;

namespace Satisfaction.Application.Queries.Franchises
{
    public class GetFranchiseQueryHandler : IRequestHandler<GetFranchiseQuery,FranchiseInfoList>
    {
        private readonly IFranchiseRepository _franchiseRepository;
        public GetFranchiseQueryHandler(IFranchiseRepository franchiseRepository)
        {
            _franchiseRepository = franchiseRepository;
        }

        public async Task<FranchiseInfoList> Handle(GetFranchiseQuery request, CancellationToken cancellationToken)
        {
            var franchiseInfos = _franchiseRepository.GetFranchiseList().Select(t => new FranchiseInfo()
            {
                FranchiseId=t.FranchiseId,
                CompanyId=t.CompanyId,
                BranchCode=t.BranchCode,
                BranchId=t.BranchId,
                BranchTitle=t.BranchTitle,
                IsActive=t.IsActive
            }).ToList();

            return new FranchiseInfoList {FranchiseInfos = franchiseInfos };
        }
    }
}
