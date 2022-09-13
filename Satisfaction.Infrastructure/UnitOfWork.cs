using Satisfaction.Domain.SeedWork;
using Satisfaction.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Satisfaction.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly SatisfactionContext _satisfactionContext;
        public UnitOfWork(SatisfactionContext satisfactionContext)
        {
            _satisfactionContext = satisfactionContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            if (!_satisfactionContext.ChangeTracker.HasChanges()) return 0;
            try
            {
                return await _satisfactionContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _satisfactionContext.Dispose();
        }
    }
}
