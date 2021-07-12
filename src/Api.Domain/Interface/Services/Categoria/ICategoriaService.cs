using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Categoria;
using Api.Domain.Dtos.FilmeCategoria;

namespace Api.Domain.Interface.Services.Categoria
{
    public interface ICategoriaService
    {
        Task<CategoriaDto> Get (int id);
         Task<IEnumerable<CategoriaDto>> GetAll ();
         Task<bool> Delete (int id);
         Task<CategoriaDtoCompleto> GetCompleto (int id);
         Task<CategoriaDto> Post (CategoriaDtoCreate categoria);
         Task<CategoriaDto> Put (int id, CategoriaDtoUpdate categoria);
        Task<CategoriaDto> AdicionarFilmeCategoria (FilmeCategoriaDto filmeCategoria);
         Task<CategoriaDto> RemoverFilmeCategoria (FilmeCategoriaDto filmeCategoria);
    }
}