using ResenhaFilmesAPI.Models;

namespace ResenhaFilmesAPI.Repositories.Contracts
{
    public interface IVisitanteRepository
    {
        Task<IEnumerable<VisitanteModel>> GetAll();
    }
}
