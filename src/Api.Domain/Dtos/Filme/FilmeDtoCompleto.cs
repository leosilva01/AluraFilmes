using System.Collections.Generic;
using Api.Domain.Dtos.Ator;
using Api.Domain.Dtos.Categoria;
using Api.Domain.Dtos.Idioma;
using Api.Domain.Enum;

namespace Api.Domain.Dtos.Filme
{
    public class FilmeDtoCompleto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public short Duracao { get; set; }
        public string Descricao { get; set; }
        public string AnoLancamento { get; set; }
        public IdiomaDto IdiomaFalado { get; set; }
        public IdiomaDto IdiomaOriginal { get; set; }
        public IEnumerable<AtorDto> Atores { get; set; }
        public IEnumerable<CategoriaDto> Categorias { get; set; }
        public ClassificacaoIndicativa Classificacao { get; set; }
    }
}