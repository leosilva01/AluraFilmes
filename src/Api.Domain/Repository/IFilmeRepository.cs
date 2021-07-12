using System.Threading.Tasks;
using Api.Domain.Dtos.FilmeAtor;
using Api.Domain.Entities;
using Api.Domain.Interface;

namespace Api.Data.Repository
{
    public interface IFilmeRepository : IRepository<FilmeEntity>
    {
        Task<FilmeEntity> GetCompleteById(int id);
        Task<FilmeEntity> AddAtorFilme(AddAtorFilmeDto addAtorFilme);
        Task<FilmeEntity> RemoveAtorFilme(AddAtorFilmeDto removeAtorFilme);
    }
}