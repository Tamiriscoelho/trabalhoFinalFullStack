using Microsoft.EntityFrameworkCore;
using ResenhaFilmesAPI.Context;
using ResenhaFilmesAPI.Models;
using ResenhaFilmesAPI.Repositories.Contracts;

namespace ResenhaFilmesAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context) 
        {
            _context = context;
        
        }

        public async Task<UsuarioModel> Create(UsuarioModel usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            
            return usuario;
        }

        public async Task<UsuarioModel> Update(UsuarioModel usuario)
        {
            var existiUsuario = await _context.Usuarios.FindAsync(usuario.IdUsuario);
            if (existiUsuario == null)
                return null;

            existiUsuario.Nome = usuario.Nome;
            existiUsuario.Email = usuario.Email;
            existiUsuario.Login = usuario.Login;
            existiUsuario.Senha = usuario.Senha;

            await _context.SaveChangesAsync();

            return existiUsuario;

        }

        public async Task<UsuarioModel> Delete(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return null;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;

        }

        public async Task<UsuarioModel> GetById(int id)
        {
            var result = await _context.Usuarios.FindAsync(id);
            if (result == null)
            {
                // Tratar o caso em que não há correspondência
                // Exemplo: lançar uma exceção ou retornar um valor padrão
                throw new InvalidOperationException("Visitante não encontrado");
            }
            return result;
        }

        public async Task<UsuarioModel> GetByLoginSenha(string login, string senha)
        {
            return await _context.Usuarios
            .SingleOrDefaultAsync(v => v.Login.ToUpper() == login.ToUpper() && v.Senha.ToUpper() == senha.ToUpper());
        }

        public async Task<UsuarioModel> GetByName(string nome)
        {
            var usuario = await _context.Usuarios
         .FirstOrDefaultAsync(v => v.Nome == nome);

            if (usuario == null)
            {
                throw new InvalidOperationException($"Visitante com o nome {nome} não encontrado");
            }

            return usuario;
        }

        public async Task<IEnumerable<UsuarioModel>> GetAll()
        {
            return await _context.Usuarios.ToListAsync();
        }

    }
}
