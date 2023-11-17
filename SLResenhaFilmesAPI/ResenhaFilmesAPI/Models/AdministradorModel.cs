namespace ResenhaFilmesAPI.Models
{
    public class AdministradorModel : UsuarioModel
    {
        public List<FilmeModel>? Filmes { get; set; }
    }
} 
