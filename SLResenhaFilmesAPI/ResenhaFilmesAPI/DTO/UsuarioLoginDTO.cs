using System.ComponentModel.DataAnnotations;

namespace ResenhaFilmesAPI.DTO
{
    public class UsuarioLoginDTO
    {
        public string Login { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        public string Roles { get; set; } = string.Empty;
    }
}
