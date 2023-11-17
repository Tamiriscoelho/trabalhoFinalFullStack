using Microsoft.EntityFrameworkCore;
using ResenhaFilmesAPI.Context;
using ResenhaFilmesAPI.Models;
using ResenhaFilmesAPI.Repositories.Contracts;

namespace ResenhaFilmesAPI.Repositories
{
    public class VisitanteRepository : IVisitanteService
    {
        private readonly AppDbContext _context;

        public VisitanteRepository(AppDbContext context) 
        {
            _context = context;
        
        }

        public async Task<VisitanteModel> Create(VisitanteModel visitante)
        {
            _context.Visitantes.Add(visitante);
            await _context.SaveChangesAsync();
            
            return visitante;
        }

        public async Task<VisitanteModel> Update(VisitanteModel visitante)
        {
            var existingVisitante = await _context.Visitantes.FindAsync(visitante.Id);
            if (existingVisitante == null)
                return null;

            existingVisitante.Nome = visitante.Nome;
            existingVisitante.Email = visitante.Email;
            existingVisitante.Login = visitante.Login;
            existingVisitante.Senha = visitante.Senha;

            await _context.SaveChangesAsync();

            return existingVisitante;

        }

        public async Task<VisitanteModel> Delete(int id)
        {
            var visitante = await _context.Visitantes.FindAsync(id);
            if (visitante == null)
                return null;

            _context.Visitantes.Remove(visitante);
            await _context.SaveChangesAsync();

            return visitante;

        }

        public async Task<VisitanteModel> GetById(int id)
        {
            var result = await _context.Visitantes.FindAsync(id);
            if (result == null)
            {
                // Tratar o caso em que não há correspondência
                // Exemplo: lançar uma exceção ou retornar um valor padrão
                throw new InvalidOperationException("Visitante não encontrado");
            }
            return result;
        }

        public async Task<VisitanteModel> GetByLoginSenha(string login, string senha)
        {
            return await _context.Visitantes
            .SingleOrDefaultAsync(v => v.Login == login && v.Senha == senha);
        }

        public async Task<VisitanteModel> GetByName(string nome)
        {
            var visitante = await _context.Visitantes
         .FirstOrDefaultAsync(v => v.Nome == nome);

            if (visitante == null)
            {
                throw new InvalidOperationException($"Visitante com o nome {nome} não encontrado");
            }

            return visitante;
        }

        public async Task<IEnumerable<VisitanteModel>> GetAll()
        {
            return await _context.Visitantes.ToListAsync();
        }

    }
}
