using ResenhaFilmesAPI.Models;

namespace ResenhaFilmesAPI.Repositories.Contracts
{
    public interface IAdmistradorRepository
    {
        Task<AdministradorModel> Create(AdministradorModel administrador);

        Task<AdministradorModel> Update(AdministradorModel administrador);

        Task<AdministradorModel> Delete(int id);

        Task<AdministradorModel> GetById(int id);

        Task<AdministradorModel> GetByLoginSenha(string login, string senha);

        Task<AdministradorModel> GetByName(string nome);

        Task<IEnumerable<AdministradorModel>> GetAll();

       
    }

}

