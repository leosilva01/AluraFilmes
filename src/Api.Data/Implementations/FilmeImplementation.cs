using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Dtos.Filme;
using Api.Domain.Dtos.FilmeAtor;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class FilmeImplementation : BaseRepository<FilmeEntity>, IFilmeRepository
    {
        private DbSet<FilmeEntity> _dataSet;
        public FilmeImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<FilmeEntity>();
        }

        
        public async Task<FilmeEntity> GetCompleteById(int id)
        {
            // var entity = await _dataSet
            //     .Include(fa => fa.FilmesAtores)
            //     .ThenInclude(f => f.Ator)
            //     .Include(f => f.IdiomaFalado)
            //     .Include(f => f.IdiomaOriginal)
            //     // .Include(ca => ca.Categorias)
            //     // .ThenInclude(f => f.Categoria)
            //     .FirstOrDefaultAsync(f => f.Id == id);

            var entity = await _dataSet
                .Include(a => a.Atores)
                .Include(a => a.IdiomaFalado)
                .Include(a => a.IdiomaOriginal)
                .Include(a => a.Categorias)
                .FirstOrDefaultAsync(f => f.Id == id);

                return entity;
        }
        public override async Task<FilmeEntity> InsertAsync(FilmeEntity item)
        {
            // Verifica se os Idiomas já existem, caso existam usa os do banco de dados senão cria um Idioma novo.
            if(item.IdiomaFalado.Id != 0){
                var idioma = await _context.Idiomas.SingleOrDefaultAsync(p => p.Id.Equals(item.IdiomaFalado.Id));
                if(idioma != null){
                    item.IdiomaFalado = idioma;
                }
            } else {
                var idioma = await _context.Idiomas.SingleOrDefaultAsync(p => p.Nome.Equals(item.IdiomaFalado.Nome));
                if(idioma != null){
                    item.IdiomaFalado = idioma;
                }

            }

            if(item.IdiomaOriginal != null){
                if(item.IdiomaOriginal.Id != 0) {
                    var idioma = await _context.Idiomas.SingleOrDefaultAsync(p => p.Id.Equals(item.IdiomaOriginal.Id));
                    if(idioma != null)
                        item.IdiomaOriginal = idioma;
                    
                } else {
                    var idioma = await _context.Idiomas.SingleOrDefaultAsync(p => p.Nome.Equals(item.IdiomaOriginal.Nome));
                    if(idioma != null){
                        item.IdiomaOriginal = idioma;
                    }
                }
            } 
            
            var atores = new HashSet<AtorEntity>();


            if(item.Atores.Count > 0){

                foreach(var ator in item.Atores){
                    
                    // Verifica se o ator já existe, caso exista usa ele
                    var atorExistente = await _context.Atores.SingleOrDefaultAsync(p => p.Id.Equals(ator.Id));

                    // Se o ator nao existir cria um novo.
                    if(atorExistente == null){

                        var novoAtor = new AtorEntity {
                            PrimeiroNome = ator.PrimeiroNome,
                            UltimoNome = ator.UltimoNome
                        };

                        atores.Add(novoAtor);

                    } else {

                        atores.Add(atorExistente);

                    }
                }
            }

            //  substitui a lista por uma lista que o entity esteja trackeando.
            item.Atores = atores;

            _dataSet.Add(item);

            // Salvamento feito na Unit Of Work para garantir q tudo será salvo ao mesmo tempo.
            // await _context.SaveChangesAsync();

            return item;
        }
        public override async Task<FilmeEntity> UpdateAsync(int filmeId, FilmeEntity item)
        {
            var filmeExiste = await _context.Filmes.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

            if(filmeExiste == null){
                    return null;
            }

            if(item.IdiomaFalado.Id != 0){
                item.IdiomaFalado = await _context.Idiomas.SingleOrDefaultAsync(p => p.Id.Equals(item.IdiomaFalado.Id));
            
            }
            if(item.IdiomaOriginal.Id != 0){
                item.IdiomaOriginal = await _context.Idiomas.SingleOrDefaultAsync(p => p.Id.Equals(item.IdiomaOriginal.Id));
            }

            // Atualizando as Shadow Properties.
            _context.Entry(filmeExiste).Property("last_update").CurrentValue = DateTime.Now;

            // Não sei porque não esta atualizando a chave estrangeira quando atualizo o objeto Idioma, precisa atualizar a shadow property.
            _context.Entry(filmeExiste).Property("language_id").CurrentValue = item.IdiomaFalado.Id;
            _context.Entry(filmeExiste).Property("original_language_id").CurrentValue = item.IdiomaOriginal.Id;

            
            // nao sei como fazer update do many to many no update, como saber quando é pra excluir um valor ou criar um valor novo.
            
            // var atores = new List<AtorEntity>();

            // if(item.Atores.Count > 0){

            //     foreach(var ator in item.Atores){
                    
            //         var atorExistente = await _context.Atores.SingleOrDefaultAsync(p => p.Id.Equals(ator.Id));

            //         if(atorExistente == null){

            //             var novoAtor = new AtorEntity {
            //                 PrimeiroNome = ator.PrimeiroNome,
            //                 UltimoNome = ator.UltimoNome
            //             };

            //             atores.Add(novoAtor);

            //         } else {

            //             atores.Add(atorExistente);

            //         }
            //     }
            // }

            // item.Atores = atores;

            _context.Entry(filmeExiste).CurrentValues.SetValues(item);

            // await _context.SaveChangesAsync();

            return item;
        }
        public async Task<FilmeEntity> RemoveAtorFilme(AddAtorFilmeDto removeAtorFilme)
        {

            var filme = await _context.Filmes
                .Include(a => a.Atores)
                .Include(a => a.IdiomaFalado)
                .Include(a => a.IdiomaOriginal)
                .FirstOrDefaultAsync(f => f.Id == removeAtorFilme.FilmeId);

            if(filme == null)
            {
                return null;
            }

            var ator = await _context.Atores.FirstOrDefaultAsync(a => a.Id == removeAtorFilme.AtorId);

            if(ator == null)
            {
                return null;
            }

            filme.Atores.Remove(ator);

            return filme;

        // Feito no Unit Of Work
        //     await _context.SaveChangesAsync();


        // Implementação sem includes.
        // var filmeAtor = await _context.FilmesAtores.FirstOrDefaultAsync(f => f.FilmeId == removeAtorFilme.FilmeId && f.AtorId == removeAtorFilme.AtorId);
            
        //     if(filmeAtor != null)
        //     {
        //         _context.FilmesAtores.Remove(filmeAtor);
        //     }

        //     return await _context.Filmes.FirstOrDefaultAsync(f => f.Id == removeAtorFilme.FilmeId);

        }
        public async Task<FilmeEntity> AddAtorFilme(AddAtorFilmeDto AddAtorFilme)
        {

            var filme = await _context.Filmes
                .Include(a => a.Atores)
                .Include(a => a.IdiomaFalado)
                .Include(a => a.IdiomaOriginal)
                .FirstOrDefaultAsync(f => f.Id == AddAtorFilme.FilmeId);

            if(filme == null)
            {
                return null;
            }

            var ator = await _context.Atores.FirstOrDefaultAsync(a => a.Id == AddAtorFilme.AtorId);

            if(ator == null)
            {
                return null;
            }

            filme.Atores.Add(ator);

            return filme;
        
        // Feito no Unit Of Work
        // await _context.SaveChangesAsync();

        // Implementação sem includes.
            // var filmeAtor = await _context.FilmesAtores.FirstOrDefaultAsync(f => f.FilmeId == AddAtorFilme.FilmeId && f.AtorId == AddAtorFilme.AtorId);
            
            // if(filmeAtor == null)
            // {
            //     // var ator = await _context.Atores.FirstOrDefaultAsync(a => a.Id == AddAtorFilme.AtorId);
            //     // var filme = await _context.Filmes.FirstOrDefaultAsync(a => a.Id == AddAtorFilme.FilmeId);
                
            //     var novoFilmeAtor = new FilmeAtorEntity{
            //         AtorId = AddAtorFilme.AtorId,
            //         FilmeId = AddAtorFilme.FilmeId,
            //         // Ator = ator,
            //         // Filme = filme
            //     };
                
            //     _context.FilmesAtores.Add(novoFilmeAtor);
            // }

            // return await _context.Filmes.FirstOrDefaultAsync(f => f.Id == AddAtorFilme.FilmeId);
        }
    }
}