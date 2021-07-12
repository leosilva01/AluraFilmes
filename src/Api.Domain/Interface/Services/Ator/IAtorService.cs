using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Ator;
using Api.Domain.Entities;

namespace Api.Domain.Interface.Services.Ator
{
    public interface IAtorService
    {
         Task<AtorDto> Get (int id);
         Task<AtorDtoCompleto> GetCompleto (int id);
         Task<IEnumerable<AtorDto>> GetAll ();
         Task<AtorDto> Post (AtorDtoCreate ator);
         Task<AtorDto> Put (int atorId, AtorDtoUpdate ator);
         Task<bool> Delete (int id);
         Task<IEnumerable<AtoresPorCategoriaResult>> PorCategoria (string categoria);
         Task<IEnumerable<Top5AtoresComMaisFilmesResult>> Top5 ();
    }
}