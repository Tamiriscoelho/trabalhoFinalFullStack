using ResenhaFilmesAPI.Models;

namespace ResenhaFilmesAPI.Repositories.Contracts
{
    public interface IUsuarioRepository
    {
   
        Task<UsuarioModel> Create(UsuarioModel visitante);

        Task<UsuarioModel> Update(UsuarioModel visitante);

        Task<UsuarioModel> Delete(int id);

        Task<UsuarioModel> GetById(int id);

        Task<UsuarioModel> GetByLoginSenha(string login, string senha);

        Task<UsuarioModel> GetByName(string nome);

        Task<IEnumerable<UsuarioModel>> GetAll();
    }
}
