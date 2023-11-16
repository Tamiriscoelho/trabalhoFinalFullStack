namespace ResenhaFilmesAPI.Models
{
    public class VisitanteModel : UsuarioModel
    {
        public List<FilmeModel>? Filmes{ get; set; }
    }
}
