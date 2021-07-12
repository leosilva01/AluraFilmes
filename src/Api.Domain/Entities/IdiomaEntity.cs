using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class IdiomaEntity : BaseEntity
    {
        public string Nome { get; set; }
        public ICollection<FilmeEntity> FilmesFalados { get; set; }
        public ICollection<FilmeEntity> FilmesOriginais { get; set; }

        public IdiomaEntity()
        {
            FilmesFalados = new List<FilmeEntity>();
            FilmesOriginais = new List<FilmeEntity>();
        }
    }
}