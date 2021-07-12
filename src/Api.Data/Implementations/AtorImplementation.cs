using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class AtorImplementation : BaseRepository<AtorEntity>, IAtorRepository
    {
        private DbSet<AtorEntity> _dataSet;
        private DbSet<AtoresPorCategoriaResult> _dataSetProc;
        private DbSet<Top5AtoresComMaisFilmesResult> _dataSetVw;

        public AtorImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<AtorEntity>();
            _dataSetProc = context.Set<AtoresPorCategoriaResult>();
            _dataSetVw = context.Set<Top5AtoresComMaisFilmesResult>();
        }

        public async Task<AtorEntity> GetCompleteById(int id)
        {
            var entity = await _dataSet
                .Include(a => a.Filmes)
                .FirstOrDefaultAsync(f => f.Id == id);

                return entity;
        }

        public async Task<IEnumerable<AtoresPorCategoriaResult>> GetPorCategoria(string categoria)
        {

            var result = await _dataSetProc
                .FromSqlInterpolated($"call actors_from_given_category ({categoria})").ToListAsync();

           return result;
        }

        public async Task<IEnumerable<Top5AtoresComMaisFilmesResult>> Top5Atores()
        {
            return await _dataSetVw.ToListAsync();
        }
    }
}