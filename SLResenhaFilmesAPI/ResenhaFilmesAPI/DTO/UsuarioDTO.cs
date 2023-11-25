using ResenhaFilmesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace ResenhaFilmesAPI.DTO
{
    public class UsuarioDTO
    {
        
        public int UsuarioModelId { get; set; }

       
        public string Nome { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

       
        public string Login { get; set; } = string.Empty;

       
        public string Senha { get; set; } = string.Empty;

        public string? Roles{ get; set; } = string.Empty;

        public List<ResenhaModel>? Resenhas { get; set; }
    }
}
