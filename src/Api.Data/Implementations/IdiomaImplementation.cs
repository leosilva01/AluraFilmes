using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class IdiomaImplementation : BaseRepository<IdiomaEntity>, IIdiomaRepository
    {
        private DbSet<IdiomaEntity> _dataSet;
        public IdiomaImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<IdiomaEntity>();
        }

        public async Task<IdiomaEntity> GetCompleteById(int id)
        {
            var entity = await _dataSet
                .Include(a => a.FilmesFalados)
                .Include(a => a.FilmesOriginais)
                .FirstOrDefaultAsync(f => f.Id == id);

                return entity;
        }
    }
}