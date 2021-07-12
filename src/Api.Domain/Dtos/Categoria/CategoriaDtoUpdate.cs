using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Categoria
{
    public class CategoriaDtoUpdate
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório."),
            StringLength(25, MinimumLength = 1, ErrorMessage = "Intervalo permitido de 1 a 25 caracteres.")]
        public string Nome { get; set; }
    }
}