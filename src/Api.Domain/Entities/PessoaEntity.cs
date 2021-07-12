namespace Api.Domain.Entities
{
    public class PessoaEntity : BaseEntity
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
    }
}