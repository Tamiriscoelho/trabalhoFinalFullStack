using ResenhaFilmesAPI.Models;

namespace ResenhaFilmesAPI.DTO
{
    public class FilmeDTO
    {
        public int IdFilme { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public string Genero { get; set; } = string.Empty;

        public string Ano { get; set; } = string.Empty;

        public virtual List<ResenhaModel>? Resenhas { get; set; }
    }
}
