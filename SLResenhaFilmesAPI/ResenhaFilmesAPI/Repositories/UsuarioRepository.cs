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
            _context.Usuarios.Add(usuario);//crio no context
            await _context.SaveChangesAsync();// perssito no banco
            
            return usuario;
        }

        public async Task<UsuarioModel> Update(UsuarioModel usuario)
        {
            var existiUsuario = await _context.Usuarios.FindAsync(usuario.UsuarioModelId);
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
            //faz uma busca na memoria FindAsync
            var usuarioModel = await _context.Usuarios.FindAsync(id);
            if (usuarioModel == null)
            {
                // Tratar o caso em que não há correspondência
                // Exemplo: lançar uma exceção ou retornar um valor padrão
                throw new InvalidOperationException("Usuário não encontrado");
            }
            return usuarioModel;
        }

        public async Task<UsuarioModel> GetByLoginSenha(string login, string senha)
        {
            return await _context.Usuarios
            .SingleOrDefaultAsync(v => v.Login.ToUpper() == login.ToUpper() && v.Senha.ToUpper() == senha.ToUpper());
        }

        public async Task<IEnumerable<UsuarioModel>> GetByName(string nome)
        {
            IEnumerable<UsuarioModel> usuarioModels;

            if (!string.IsNullOrWhiteSpace(nome))
            {
                usuarioModels = await _context.Usuarios.Where(n => n.Nome.Contains(nome)).ToListAsync();
            }
            else
            {
                usuarioModels = await GetAll();
            }

            return usuarioModels;
        }

        public async Task<IEnumerable<UsuarioModel>> GetAll()
        {
            return await _context.Usuarios.ToListAsync();
        }

    }
}
