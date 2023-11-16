using ResenhaFilmesAPI.Models;

namespace ResenhaFilmesAPI.DTO
{
    public class FilmeDTO
    {
        private int Id { get; set; }

        private string Genero { get; set; } = string.Empty;

        private string Ano { get; set; } = string.Empty;

        private List<ResenhaModel>? Resenhas { get; set; }
    }
}
