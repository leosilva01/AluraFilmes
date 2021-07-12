using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Dtos.Ator;
using Api.Domain.Dtos.Idioma;
using Api.Domain.Enum;

namespace Api.Domain.Dtos.Filme
{
    public class FilmeDtoCreate
    {
        public FilmeDtoCreate(string titulo)
        {
            if(titulo.Length <= 10)
                throw new ArgumentException("teste");
            Titulo = titulo;
        }

        [Required(ErrorMessage = "O campo {0} é obrigatório."),
            StringLength(255, MinimumLength = 1, ErrorMessage = "Intervalo permitido de 1 a 255 caracteres.")]
        public string Titulo { get; set; }
        
        
        [Required(ErrorMessage = "O campo {0} é obrigatório."),
            Range(1, 500, ErrorMessage = "Duração fora do Intervalo.")]
        public short Duracao { get; set; }
        
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Descricao { get; set; }

        
        [Required(ErrorMessage = "O campo {0} é obrigatório."),
            StringLength(4, MinimumLength = 1, ErrorMessage = "Ano fora do Intervalo.")]
        public string AnoLancamento { get; set; }
        
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public IdiomaDto IdiomaFalado { get; set; }
        
        
        public IdiomaDto IdiomaOriginal { get; set; }
        public IEnumerable<AtorDto> Atores { get; set; }
        public ClassificacaoIndicativa Classificacao { get; set; }
    }
}