using ResenhaFilmesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace ResenhaFilmesAPI.DTO
{
    public class AdministradorDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Login { get; set; } = string.Empty;


        [Required]
        [StringLength(20)]
        public string Senha { get; set; } = string.Empty;
    }
}
