using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Filme;
using Api.Domain.Dtos.FilmeAtor;

namespace Api.Domain.Interface.Services.Filme
{
    public interface IFilmeService
    {
         Task<FilmeDto> Get (int id);
         Task<FilmeDtoCompleto> GetCompleto (int id);
         Task<IEnumerable<FilmeDto>> GetAll ();
         Task<FilmeDto> Post (FilmeDtoCreate filme);
         Task<FilmeDto> Put (int FilmeId, FilmeDtoUpdate filme);
         Task<bool> Delete (int id);
         Task<FilmeDtoCompleto> AdicionarAtorFilme (AddAtorFilmeDto atorFilme);
         Task<FilmeDtoCompleto> RemoverAtorFilme (AddAtorFilmeDto atorFilme);
    }
}