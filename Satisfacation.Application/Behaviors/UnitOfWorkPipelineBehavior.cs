using MediatR;
using Satisfaction.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Satisfaction.Application.Behaviors
{
    public class UnitOfWorkPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>

    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkPipelineBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return response;
        }
    }
}
