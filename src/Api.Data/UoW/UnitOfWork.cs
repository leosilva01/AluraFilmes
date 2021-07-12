using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Interface;

namespace Api.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _context;

        public UnitOfWork(MyContext context)
        {
            _context = context;
        }
        public async Task<bool> Commit()
        {
            var success = (await _context.SaveChangesAsync()) > 0;

            return success;
        }

        public Task Rollback()
        {
            // não tem implementação de rollback.
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}