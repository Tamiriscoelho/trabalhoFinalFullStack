using ResenhaFilmesAPI.Models;
using System.Text.Json.Serialization;

namespace ResenhaFilmesAPI.DTO
{
    public class ResenhaDTO
    {
        public int Id { get; set; }

        public int Nota { get; set; }

        public string Comentario { get; set; } = string.Empty;

        public int UsuarioModelId { get; set; }

        public int IdFilme { get; set; }
    }
}
