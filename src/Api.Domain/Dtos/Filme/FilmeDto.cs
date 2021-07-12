using Api.Domain.Dtos.Idioma;
using Api.Domain.Enum;

namespace Api.Domain.Dtos.Filme
{
    public class FilmeDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public short Duracao { get; set; }
        public string Descricao { get; set; }
        public string AnoLancamento { get; set; }
        public ClassificacaoIndicativa Classificacao { get; set; }
    }
}