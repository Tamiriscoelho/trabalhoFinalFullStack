using ResenhaFilmesAPI.DTO;
using ResenhaFilmesAPI.Models;

namespace ResenhaFilmesAPI.Service.Contracts
{
    public interface IResenhaService
    {
        Task Create(ResenhaDTO resenha);

        Task Update(ResenhaDTO resenha);

        Task Delete(int id);

        Task <ResenhaDTO> GetById(int id);

        Task<IEnumerable<ResenhaDTO>> GetByNota(int nota);

        Task<IEnumerable<ResenhaDTO>> GetAll();
    }
}
