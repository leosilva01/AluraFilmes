using System.Collections.Generic;
using Api.Domain.Dtos.Filme;

namespace Api.Domain.Dtos.Idioma
{
    public class IdiomaDtoCompleto
    {
        public string Nome { get; set; }
        public ICollection<FilmeDto> FilmesFalados { get; set; }
        public ICollection<FilmeDto> FilmesOriginais { get; set; }
    }
}