using System.Collections.Generic;
using Api.Domain.Dtos.Filme;

namespace Api.Domain.Dtos.Ator
{
    public class AtorDtoCompleto
    {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public IEnumerable<FilmeDto> Filmes { get; set; }

    }
}