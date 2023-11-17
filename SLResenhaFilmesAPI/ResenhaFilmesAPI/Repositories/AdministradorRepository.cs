using Microsoft.EntityFrameworkCore;
using ResenhaFilmesAPI.Context;
using ResenhaFilmesAPI.Models;
using ResenhaFilmesAPI.Repositories.Contracts;

namespace ResenhaFilmesAPI.Repositories
{
    public class AdministradorRepository : IAdmistradorRepository
    {
        private readonly AppDbContext _context;

        public AdministradorRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task<AdministradorModel> Create(AdministradorModel administrador)
        {
            _context.Administradores.Add(administrador);
            await _context.SaveChangesAsync();

            return administrador;
        }

        public async Task<AdministradorModel> Update(AdministradorModel administrador)
        {
            var existingAdministrador = await _context.Administradores.FindAsync(administrador.Id);
            if (existingAdministrador == null)
                return null;

            existingAdministrador.Nome = administrador.Nome;
            existingAdministrador.Email = administrador.Email;
            existingAdministrador.Login = administrador.Login;
            existingAdministrador.Senha = administrador.Senha;

            await _context.SaveChangesAsync();

            return existingAdministrador;

        }

        public async Task<AdministradorModel> Delete(int id)
        {
            var administrador = await _context.Administradores.FindAsync(id);
            if (administrador == null)
                return null;

            _context.Administradores.Remove(administrador);
            await _context.SaveChangesAsync();

            return administrador;

        }

        public async Task<AdministradorModel> GetById(int id)
        {
            var result = await _context.Administradores.FindAsync(id);
            if (result == null)
            {
                // Tratar o caso em que não há correspondência
                // Exemplo: lançar uma exceção ou retornar um valor padrão
                throw new InvalidOperationException("Visitante não encontrado");
            }
            return result;
        }

        public async Task<AdministradorModel> GetByLoginSenha(string login, string senha)
        {
            return await _context.Administradores
            .SingleOrDefaultAsync(v => v.Login == login && v.Senha == senha);
        }

        public async Task<AdministradorModel> GetByName(string nome)
        {
            var administrador = await _context.Administradores
         .FirstOrDefaultAsync(v => v.Nome == nome);

            if (administrador == null)
            {
                throw new InvalidOperationException($"Visitante com o nome {nome} não encontrado");
            }

            return administrador;
        }

        public async Task<IEnumerable<AdministradorModel>> GetAll()
        {
            return await _context.Administradores.ToListAsync();
        }
    }

}

