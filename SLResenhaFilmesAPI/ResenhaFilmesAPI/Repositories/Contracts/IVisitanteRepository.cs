using ResenhaFilmesAPI.Models;

namespace ResenhaFilmesAPI.Repositories.Contracts
{
    public interface IVisitanteRepository
    {
   
        Task<VisitanteModel> Create(VisitanteModel visitante);

        Task<VisitanteModel> Update(VisitanteModel visitante);

        Task<VisitanteModel> Delete(int id);

        Task<VisitanteModel> GetById(int id);

        Task<VisitanteModel> GetByLoginSenha(string login, string senha);

        Task<VisitanteModel> GetByName(string nome);

        Task<IEnumerable<VisitanteModel>> GetAll();
    }
}
