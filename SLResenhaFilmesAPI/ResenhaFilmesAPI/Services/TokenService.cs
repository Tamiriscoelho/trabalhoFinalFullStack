using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using ResenhaFilmesAPI.DTO;
using ResenhaFilmesAPI.Models;
using ResenhaFilmesAPI.Repositories.Contracts;
using ResenhaFilmesAPI.Services.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ResenhaFilmesAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;


        public TokenService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        public async Task<string> GenerateToken(UsuarioLoginDTO usuario)
        {
            var tokenHandeler = new JwtSecurityTokenHandler();

            var Key = Encoding.ASCII.GetBytes(Settings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Login), // User.Identity.Name
                    new Claim(ClaimTypes.Role, usuario.Roles) // User,IsInRole
                }),

                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandeler.CreateToken(tokenDescriptor);
            return tokenHandeler.WriteToken(token);
        }
    }
}
