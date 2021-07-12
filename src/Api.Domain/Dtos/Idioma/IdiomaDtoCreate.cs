using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Idioma
{
    public class IdiomaDtoCreate
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório."),
            StringLength(20, MinimumLength = 1, ErrorMessage = "Intervalo permitido de 1 a 20 caracteres.")]
        public string Nome { get; set; }
    }
}