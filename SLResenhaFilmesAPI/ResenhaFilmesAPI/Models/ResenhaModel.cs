using System.ComponentModel.DataAnnotations;

namespace ResenhaFilmesAPI.Models
{
    public class ResenhaModel
    {
        public int Id { get; set; }

        public int Nota { get; set; }

        public string Comentario { get; set; } = string.Empty;

    }
}
