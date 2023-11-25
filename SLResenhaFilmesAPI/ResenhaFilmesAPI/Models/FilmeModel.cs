namespace ResenhaFilmesAPI.Models
{
    public class FilmeModel
    {
        public int FilmeModelId { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public string Genero { get; set; } = string.Empty;

        public string Ano { get; set; } = string.Empty;

        public virtual List<ResenhaModel>? Resenhas { get; set; }
    }
}
