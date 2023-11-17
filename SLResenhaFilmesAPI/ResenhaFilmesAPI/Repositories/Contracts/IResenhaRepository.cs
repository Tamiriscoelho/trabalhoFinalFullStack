using ResenhaFilmesAPI.Models;

namespace ResenhaFilmesAPI.Repositories.Contracts
{
    public interface IResenhaRepository
    {
        Task<ResenhaModel> Create(ResenhaModel resenha);

        Task<ResenhaModel> Update(ResenhaModel resenha);

        Task<ResenhaModel> Delete(int id);

        Task<ResenhaModel> GetById(int id);

        Task<IEnumerable<ResenhaModel>> GetByNota(int nota);

        Task<IEnumerable<ResenhaModel>> GetAll();
    }
}
