namespace Api.Domain.Entities
{
    public class CategoriaFilmeEntity
    {
        public int FilmeId { get; set; }
        public int CategoriaId { get; set; }
        public FilmeEntity Filme { get; set; }
        public CategoriaEntity Categoria { get; set; }
    }
}