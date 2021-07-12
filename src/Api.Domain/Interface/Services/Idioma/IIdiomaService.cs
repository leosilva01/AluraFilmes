using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Idioma;

namespace Api.Domain.Interface.Services.Idioma
{
    public interface IIdiomaService
    {
         Task<IdiomaDto> Get (int id);
         Task<IEnumerable<IdiomaDto>> GetAll ();
         Task<bool> Delete (int id);
         Task<IdiomaDtoCompleto> GetCompleto (int id);
         Task<IdiomaDto> Post (IdiomaDtoCreate idioma);
         Task<IdiomaDto> Put (int id, IdiomaDtoUpdate idioma);
    }
}