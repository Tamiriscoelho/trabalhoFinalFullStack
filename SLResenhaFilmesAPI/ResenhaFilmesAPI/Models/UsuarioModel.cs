using System.ComponentModel.DataAnnotations;

namespace ResenhaFilmesAPI.Models
{
    public class UsuarioModel
    {
        //o Entity reconhece que essa propriedade vai ser mapeada para uma
        //coluna na tabela que ele vai criar com chave primaria do tipo identity
        public int UsuarioModelId { get; set; }

        public string Nome { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Login { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;

        public string Roles { get; set; } = string.Empty;

        public virtual List<ResenhaModel>? Resenhas { get; set; }
    }
}
