using System.ComponentModel.DataAnnotations;

namespace ResenhaFilmesAPI.DTO
{
    public class AdministradorLoginDTO
    {
        [Required]
        public string Login { get; set; } = string.Empty;


        [Required]
        public string Senha { get; set; } = string.Empty;
    }
}

