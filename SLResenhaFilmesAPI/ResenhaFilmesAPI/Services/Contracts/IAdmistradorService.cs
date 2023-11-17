using ResenhaFilmesAPI.DTO;
using ResenhaFilmesAPI.Models;

namespace ResenhaFilmesAPI.Service.Contracts
{
    public interface IAdmistradorService
    {
        Task Create(AdministradorDTO administrador);

        Task Update(AdministradorDTO administrador);

        Task Delete(int id);

        Task<AdministradorLoginDTO> GetByLoginSenha(string login, string senha);

        Task<AdministradorDTO> GetByName(string nome);

        Task<IEnumerable<AdministradorDTO>> GetAll();

       
    }

}

