using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interface;

namespace Api.Domain.Repository
{
    public interface IAtorRepository : IRepository<AtorEntity>
    {
        Task<IEnumerable<AtoresPorCategoriaResult>> GetPorCategoria(string categoria);
        Task<IEnumerable<Top5AtoresComMaisFilmesResult>> Top5Atores();
        Task<AtorEntity> GetCompleteById(int id);

    }
}