using System.Collections.Generic;
using Api.Domain.Dtos.Filme;

namespace Api.Domain.Dtos.Categoria
{
    public class CategoriaDtoCompleto
    {
        public string Nome { get; set; }
        public IEnumerable<FilmeDto> Filmes { get; set; }
    }
}