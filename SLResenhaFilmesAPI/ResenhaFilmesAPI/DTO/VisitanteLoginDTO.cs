using System.ComponentModel.DataAnnotations;

namespace ResenhaFilmesAPI.DTO
{
    public class VisitanteLoginDTO
    {
        [Required]
        [StringLength(20)]
        public string Login { get; set; } = string.Empty;


        [Required]
        [StringLength(20)]
        public string Senha { get; set; } = string.Empty;
    }
}
