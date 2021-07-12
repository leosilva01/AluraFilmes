using System.ComponentModel.DataAnnotations;
using Api.Domain.Dtos.Idioma;
using Api.Domain.Enum;

namespace Api.Domain.Dtos.Filme
{
    public class FilmeDtoUpdate
    {
        
        // Não esta funcionando o required.
        public int Id { get; set; }
        
        
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
        public ClassificacaoIndicativa Classificacao { get; set; }
    }
}