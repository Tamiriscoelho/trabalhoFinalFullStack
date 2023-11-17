using ResenhaFilmesAPI.Models;

namespace ResenhaFilmesAPI.Repositories.Contracts
{
    public interface IFilmeRepository
    {
        Task<FilmeModel> Create(FilmeModel filme);

        Task<FilmeModel> Update(FilmeModel visitante);

        Task<FilmeModel> Delete(int id);

        Task<FilmeModel> GetById(int id);

        Task<IEnumerable<FilmeModel>> GetByTitulo(string titulo);

        Task<IEnumerable<FilmeModel>> GetByGenero(string genero);

        Task<IEnumerable<FilmeModel>> GetByAno(string ano);

        Task<IEnumerable<FilmeModel>> GetAll();
    }
}
