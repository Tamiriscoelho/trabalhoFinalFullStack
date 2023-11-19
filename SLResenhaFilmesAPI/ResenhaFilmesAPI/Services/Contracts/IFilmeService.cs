using Microsoft.EntityFrameworkCore;
using ResenhaFilmesAPI.DTO;
using ResenhaFilmesAPI.Models;

namespace ResenhaFilmesAPI.Service.Contracts
{
    public interface IFilmeService
    {
        Task<FilmeDTO> Create(FilmeDTO filme);

        Task Update(FilmeDTO filme);

        Task Delete (int id);

        Task <FilmeDTO> GetById(int id);

        Task<IEnumerable<FilmeDTO>> GetByTitulo(string titulo);

        Task<IEnumerable<FilmeDTO>> GetByGenero(string genero);

        Task<IEnumerable<FilmeDTO>> GetByAno(string ano);

        Task<IEnumerable<FilmeDTO>> GetAll();
    }
}
