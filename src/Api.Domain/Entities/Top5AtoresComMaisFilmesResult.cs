namespace Api.Domain.Entities
{
    public class Top5AtoresComMaisFilmesResult
    {
        public byte Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public int TotalDeFilmes { get; set; }
    }
}