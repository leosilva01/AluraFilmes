using System.Collections.Generic;
using System.Text.Json.Serialization;
using Api.Domain.Enum;

namespace Api.Domain.Entities
{
    public class FilmeEntity : BaseEntity
    {
        public string Titulo { get; set; }
        public short Duracao { get; set; }
        public string Descricao { get; set; }
        public string AnoLancamento { get; set; }
        public IdiomaEntity IdiomaFalado { get; set; }
        public IdiomaEntity IdiomaOriginal { get; set; }
        public ClassificacaoIndicativa Classificacao { get; set; }
        public ICollection<AtorEntity> Atores { get; set; }
        // public List<FilmeAtorEntity> FilmesAtores { get; set; }
        public ICollection<CategoriaEntity> Categorias { get; set; }

        public FilmeEntity()
        {
            // FilmesAtores = new List<FilmeAtorEntity>();   
            // Categorias = new List<CategoriaFilmeEntity>();   
        }
    }
}