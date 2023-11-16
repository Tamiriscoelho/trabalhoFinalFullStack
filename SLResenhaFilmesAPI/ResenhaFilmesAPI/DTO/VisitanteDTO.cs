using ResenhaFilmesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace ResenhaFilmesAPI.DTO
{
    public class VisitanteDTO
    {
        
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Login { get; set; } = string.Empty;

        [Required]
        public string Senha { get; set; } = string.Empty;
    }
}
