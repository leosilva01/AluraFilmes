using System;
using System.Threading.Tasks;

namespace Api.Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
        Task Rollback(); 
    }
}