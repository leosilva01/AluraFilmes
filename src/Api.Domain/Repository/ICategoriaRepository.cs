using System.Threading.Tasks;
using Api.Domain.Dtos.FilmeCategoria;
using Api.Domain.Entities;
using Api.Domain.Interface;

namespace Api.Domain.Repository
{
    public interface ICategoriaRepository : IRepository<CategoriaEntity>
    {
        Task<CategoriaEntity> GetCompleteById(int id);
        Task<CategoriaEntity> AdicionarFilmeCategoria(FilmeCategoriaDto filmeCategoria);
        Task<CategoriaEntity> RemoverFilmeCategoria(FilmeCategoriaDto filmeCategoria);
        
    }
}