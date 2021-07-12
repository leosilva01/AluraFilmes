using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entities
{
    [NotMapped]
    public class AtoresPorCategoriaResult
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Categoria { get; set; }
        public string NomeFilme { get; set; }
        public string DescricaoFilme { get; set; }
        public string AnoLancamento { get; set; }
        public byte Duracao { get; set; }
        public string Classificacao { get; set; }
    }
}