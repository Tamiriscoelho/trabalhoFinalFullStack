using ResenhaFilmesAPI.DTO;
using ResenhaFilmesAPI.Models;

namespace ResenhaFilmesAPI.Service.Contracts
{
    public interface IUsuarioService
    {
   
        Task<UsuarioDTO> Create(UsuarioDTO usuario);

        Task<UsuarioDTO> CreateUserAdmin(UsuarioDTO dto);

        Task<UsuarioDTO> CreateUserComum(UsuarioDTO dto);

        Task Update(UsuarioDTO usuario);

        Task Delete(int id);

        Task <UsuarioDTO> GetById(int id);

        Task <UsuarioLoginDTO> GetByLoginSenha(string login, string senha);

       Task<IEnumerable<UsuarioDTO>>GetByName(string nome);

        Task<IEnumerable<UsuarioDTO>> GetAll();
    }
}
