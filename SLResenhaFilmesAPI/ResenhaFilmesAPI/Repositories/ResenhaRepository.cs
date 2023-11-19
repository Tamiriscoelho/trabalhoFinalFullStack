using Microsoft.EntityFrameworkCore;
using ResenhaFilmesAPI.Context;
using ResenhaFilmesAPI.Models;
using ResenhaFilmesAPI.Repositories.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ResenhaFilmesAPI.Repositories
{
    public class ResenhaRepository : IResenhaRepository
    {
        private readonly AppDbContext _context;

        public ResenhaRepository(AppDbContext context)
        {
            _context = context;

        }
        public async Task<ResenhaModel> Create(ResenhaModel resenha)
        {
            _context.Resenhas.Add(resenha);
            await _context.SaveChangesAsync();

            return resenha;
        }

        public async Task<ResenhaModel> Update(ResenhaModel resenha)
        {
            _context.Entry(resenha).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return resenha;
        }

        public async Task<ResenhaModel> Delete(int id)
        {
            var resenha = await _context.Resenhas.FindAsync(id);
            if (resenha == null)
                return null;

            _context.Resenhas.Remove(resenha);
            await _context.SaveChangesAsync();

            return resenha;
        }

        public async Task<ResenhaModel> GetById(int id)
        {
            return await _context.Resenhas.Where(x => x .Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ResenhaModel>> GetByNota(int nota)
        {
            var resenhas = await _context.Resenhas.Where(v => v.Nota == nota).ToListAsync();

            return resenhas;
        }

        public async Task<IEnumerable<ResenhaModel>> GetAll()
        {
            return await _context.Resenhas.ToListAsync();
        }

    }
}
