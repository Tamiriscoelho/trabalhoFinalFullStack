using ResenhaFilmesAPI.DTO;
using ResenhaFilmesAPI.Models;

namespace ResenhaFilmesAPI.Service.Contracts
{
    public interface IVisitanteService
    {
   
        Task Create(VisitanteDTO visitante);

        Task Update(VisitanteDTO visitante);

        Task Delete(int id);

        Task <VisitanteDTO> GetById(int id);

        Task <VisitanteLoginDTO> GetByLoginSenha(string login, string senha);

        Task <VisitanteDTO> GetByName(string nome);

        Task<IEnumerable<VisitanteDTO>> GetAll();
    }
}
