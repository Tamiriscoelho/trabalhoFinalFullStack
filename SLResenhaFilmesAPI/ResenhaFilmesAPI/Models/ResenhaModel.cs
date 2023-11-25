using System.IO;
using System.Text.Json.Serialization;

namespace ResenhaFilmesAPI.Models
{
    public class ResenhaModel
    {
        public int Id { get; set; }

        public int Nota { get; set; }

        public string Comentario { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual UsuarioModel? Usuario { get; set; }

        public int UsuarioModelId { get; set; }

        [JsonIgnore]
        public virtual FilmeModel Filme { get; set; }

        public int IdFilme { get; set; }
    }
}
