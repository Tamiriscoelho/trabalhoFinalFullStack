using System.ComponentModel.DataAnnotations;

namespace ResenhaFilmesAPI.Models
{
    public class FilmeModel
    {
        private int Id { get; set; }

        private string Genero { get; set; } = string.Empty;

        private string Ano { get; set; } = string.Empty;

        private List<ResenhaModel>? Resenhas { get; set; }

    }
}
