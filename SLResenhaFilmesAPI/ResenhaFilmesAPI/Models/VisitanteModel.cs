namespace ResenhaFilmesAPI.Models
{
    public class VisitanteModel : UsuarioModel
    {
        public virtual List<ResenhaModel>? Resenhas{ get; set; }
    }
}
