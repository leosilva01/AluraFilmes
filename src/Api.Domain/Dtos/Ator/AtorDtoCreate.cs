using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Ator
{
    public class AtorDtoCreate
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório."),
            StringLength(45, MinimumLength = 2, ErrorMessage = "Intervalo permitido de 2 a 45 caracteres.")]
        public string PrimeiroNome { get; set; }
        
        
        [Required(ErrorMessage = "O campo {0} é obrigatório."),
            StringLength(45, MinimumLength = 2, ErrorMessage = "Intervalo permitido de 2 a 45 caracteres.")]
        public string UltimoNome { get; set; }
    }
}