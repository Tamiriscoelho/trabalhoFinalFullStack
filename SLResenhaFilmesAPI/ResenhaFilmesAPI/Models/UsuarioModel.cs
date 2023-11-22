namespace ResenhaFilmesAPI.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Login { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;

        public string Roles { get; set; } = string.Empty;

        public virtual List<ResenhaModel>? Resenhas { get; set; }
    }
}
