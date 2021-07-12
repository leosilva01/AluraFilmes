using System.Text.Json.Serialization;

namespace Api.Domain.Entities
{
    public class FilmeAtorEntity
    {
        public int FilmeId { get; set; }
        public int AtorId { get; set; }
        public FilmeEntity Filme { get; set; }
        public AtorEntity Ator { get; set; }
    }
}