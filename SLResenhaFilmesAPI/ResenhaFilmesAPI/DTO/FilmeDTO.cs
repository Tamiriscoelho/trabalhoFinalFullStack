using ResenhaFilmesAPI.Models;

namespace ResenhaFilmesAPI.DTO
{
    public class FilmeDTO
    {
        public int Id { get; set; }

        public string Genero { get; set; } = string.Empty;

        public string Ano { get; set; } = string.Empty;

        public List<ResenhaModel>? Resenhas { get; set; }
    }
}
