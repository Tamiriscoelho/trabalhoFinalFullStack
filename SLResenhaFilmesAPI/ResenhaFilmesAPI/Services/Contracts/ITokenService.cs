using ResenhaFilmesAPI.DTO;

namespace ResenhaFilmesAPI.Services.Contracts
{
    public interface ITokenService
    {
        Task<string> GenerateToken(UsuarioLoginDTO usuario);
    }
}
