using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<AtorEntity> Atores { get; set; }
        public DbSet<FilmeEntity> Filmes { get; set; }
        public DbSet<IdiomaEntity> Idiomas { get; set; }
        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<FilmeAtorEntity> FilmesAtores { get; set; }
        public DbSet<CategoriaEntity> Categorias { get; set; }
        public DbSet<FuncionarioEntity> Funcionarios { get; set; }
        // public DbSet<AtoresPorCategoriaResult> AtoresPorCategoria { get; set; }
        public DbSet<Top5AtoresComMaisFilmesResult> Top5AtoresComMaisFilmes { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            base.OnModelCreating(modelBuilder);

            //Para nao criar uma tabela para a procedure
            modelBuilder.Ignore<AtoresPorCategoriaResult>();

            modelBuilder.Entity<AtorEntity>(new AtorMap().Configure);
            modelBuilder.Entity<FilmeEntity>(new FilmeMap().Configure);
            modelBuilder.Entity<IdiomaEntity>(new IdiomaMap().Configure);
            modelBuilder.Entity<ClienteEntity>(new ClienteMap().Configure);
            modelBuilder.Entity<FilmeAtorEntity>(new FilmeAtorMap().Configure);
            modelBuilder.Entity<CategoriaEntity>(new CategoriaMap().Configure);
            modelBuilder.Entity<FuncionarioEntity>(new FuncionarioMap().Configure);
            modelBuilder.Entity<CategoriaFilmeEntity>(new CategoriaFilmeMap().Configure);
            modelBuilder.Entity<AtoresPorCategoriaResult>(new AtoresPorCategoriaMap().Configure);
            modelBuilder.Entity<Top5AtoresComMaisFilmesResult>(new Top5AtoresComMaisFilmesMap().Configure);

            // É possível fazer as inclusões(Seeds) dentro das classes Map(Configurations).
        }
    }
}