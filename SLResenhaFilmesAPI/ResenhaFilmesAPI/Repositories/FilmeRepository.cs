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
            return await _context.Filmes.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<FilmeModel>> GetByAno(string ano)
        {
            var filmes = await _context.Filmes.Where(v => v.Ano == ano).ToListAsync();

            return filmes;
        }

        public async Task<IEnumerable<FilmeModel>> GetByGenero(string genero)
        {
            var filmes = await _context.Filmes.Where(v => v.Genero == genero).ToListAsync();

            return filmes;
        }

        public async Task<IEnumerable<FilmeModel>> GetByTitulo(string titulo)
        {
            var filmes = await _context.Filmes
            .Where(f => f.Titulo.ToUpper().Contains(titulo.ToUpper()))
            .ToListAsync();

            return filmes;
        }

        public async Task<IEnumerable<FilmeModel>> GetAll()
        {
            return await _context.Filmes.ToListAsync();
        }
    }
}
