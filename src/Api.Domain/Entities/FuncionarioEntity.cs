namespace Api.Domain.Entities
{
    public class FuncionarioEntity : PessoaEntity
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}