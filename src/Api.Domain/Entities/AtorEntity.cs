using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class AtorEntity : BaseEntity
    {
        
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public ICollection<FilmeEntity> Filmes { get; set; }
        // public IEnumerable<FilmeAtorEntity> FilmesAtores { get; set; }

        public AtorEntity()
        {
            // Atores = new List<FilmeAtorEntity>();
        }
    }
}