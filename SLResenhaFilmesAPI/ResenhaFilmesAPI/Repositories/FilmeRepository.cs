using Microsoft.EntityFrameworkCore;
using ResenhaFilmesAPI.Context;
using ResenhaFilmesAPI.Models;
using ResenhaFilmesAPI.Repositories.Contracts;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ResenhaFilmesAPI.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly AppDbContext _context;

        public FilmeRepository(AppDbContext context)
        {
            _context = context;

        }
        public async Task<FilmeModel> Create(FilmeModel filme)
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();

            return filme;
        }

        public async Task<FilmeModel> Update(FilmeModel filme)
        {
            _context.Entry(filme).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return filme;
        }

        public async Task<FilmeModel> Delete(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null)
                return null;

            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();

            return filme;
        }

        public async Task<FilmeModel> GetById(int id)
        {
            return await _context.Filmes.Where(x => x.FilmeModelId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<FilmeModel>> GetByAno(string ano)
        {
            IEnumerable<FilmeModel> filmeModels;

            if (!string.IsNullOrWhiteSpace(ano))
            {
                filmeModels = await _context.Filmes.Where(n => n.Ano.Contains(ano)).ToListAsync();
            }
            else
            {
                filmeModels = await GetAll();
            }

            return filmeModels;
        }

        public async Task<IEnumerable<FilmeModel>> GetByGenero(string genero)
        {
            IEnumerable<FilmeModel> filmeModels;

            if (!string.IsNullOrWhiteSpace(genero))
            {
                filmeModels = await _context.Filmes.Where(n => n.Genero.Contains(genero)).ToListAsync();
            }
            else
            {
                filmeModels = await GetAll();
            }

            return filmeModels;
        }

        public async Task<IEnumerable<FilmeModel>> GetByTitulo(string titulo)
        {
            IEnumerable<FilmeModel> filmeModels;

            if (!string.IsNullOrWhiteSpace(titulo))
            {
                filmeModels = await _context.Filmes.Where(n => n.Titulo.Contains(titulo)).ToListAsync();
            }
            else
            {
                filmeModels = await GetAll();
            }

            return filmeModels;
        }

        public async Task<IEnumerable<FilmeModel>> GetAll()
        {
            return await _context.Filmes.ToListAsync();
        }
    }
}
