using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResenhaFilmesAPI.DTO;
using ResenhaFilmesAPI.Service.Contracts;
using ResenhaFilmesAPI.Services;
using ResenhaFilmesAPI.Services.Contracts;

namespace ResenhaFilmesAPI.Controllers
{
   
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;

        private readonly ITokenService _tokenService;

        

        public LoginController(IUsuarioService usuarioService, ITokenService tokenService)
        {
            _usuarioService = usuarioService;

            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] UsuarioLoginDTO usuario)
        {
            //Recupera o usuario
            var user = await _usuarioService.GetByLoginSenha(usuario.Login, usuario.Senha);

            //Verifica se o usuário existe

            if (user == null )
            {
                return NotFound(new { message = "Usuário ou senha inválidos"});
            }

            //Gera o token

            var token = _tokenService.GenerateToken(user);



            //Oculta a senha

            user.Senha ="";

            return new {
            
             user = user,

             token = token
            };

        }
    }
}
