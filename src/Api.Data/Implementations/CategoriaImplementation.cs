using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Dtos.FilmeCategoria;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class CategoriaImplementation : BaseRepository<CategoriaEntity>, ICategoriaRepository
    {
        private DbSet<CategoriaEntity> _dataSet;
        public CategoriaImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<CategoriaEntity>();
        }

        public async Task<CategoriaEntity> GetCompleteById(int id)
        {
            var entity = await _dataSet
                .Include(a => a.Filmes)
                .FirstOrDefaultAsync(f => f.Id == id);

                return entity;
        }

        public async Task<CategoriaEntity> RemoverFilmeCategoria(FilmeCategoriaDto filmeCategoria)
        {
            var categoria = await _context.Categorias
            .Include(a => a.Filmes)
            .FirstOrDefaultAsync(f => f.Id == filmeCategoria.CategoriaId);

            if(categoria == null)
            {
                return null;
            }

            var filme = await _context.Filmes.FirstOrDefaultAsync(a => a.Id == filmeCategoria.FilmeId);

            if(filme == null)
            {
                return null;
            }

            categoria.Filmes.Remove(filme);

            // await _context.SaveChangesAsync();

            return categoria;
        }

        public async Task<CategoriaEntity> AdicionarFilmeCategoria(FilmeCategoriaDto filmeCategoria)
        {
            var categoria = await _context.Categorias
            .Include(a => a.Filmes)
            .FirstOrDefaultAsync(f => f.Id == filmeCategoria.CategoriaId);

            if(categoria == null)
            {
                return null;
            }

            var filme = await _context.Filmes.FirstOrDefaultAsync(a => a.Id == filmeCategoria.FilmeId);

            if(filme == null)
            {
                return null;
            }

            categoria.Filmes.Add(filme);

            // await _context.SaveChangesAsync();

            return categoria;
        }
    }
}