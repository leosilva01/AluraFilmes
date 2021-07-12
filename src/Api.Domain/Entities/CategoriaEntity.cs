
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class CategoriaEntity : BaseEntity
    {
        public string Nome { get; set; }
        public ICollection<FilmeEntity> Filmes { get; set; }
    }
}