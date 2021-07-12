using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interface;

namespace Api.Domain.Repository
{
    public interface IIdiomaRepository : IRepository<IdiomaEntity>
    {
        Task<IdiomaEntity> GetCompleteById(int id);
    }
}