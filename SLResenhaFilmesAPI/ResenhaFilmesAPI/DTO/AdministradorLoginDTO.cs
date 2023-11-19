using System.ComponentModel.DataAnnotations;

namespace ResenhaFilmesAPI.DTO
{
    public class AdministradorLoginDTO
    {
        
        public string Login { get; set; } = string.Empty;


        public string Senha { get; set; } = string.Empty;
    }
}

