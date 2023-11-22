using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ResenhaFilmesAPI.DTO;
using ResenhaFilmesAPI.Service.Contracts;
using ResenhaFilmesAPI.Services;

namespace ResenhaFilmesAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    
    [ApiController]
   
    public class UsuarioController : ControllerBase
    {
       private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> Get()
        {
            var dtos = await _usuarioService.GetAll();

            if (dtos is null)
                return NotFound("Usuario not found");

            return Ok(dtos);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<UsuarioDTO>> GetById(int id)
        {
            var dto = await _usuarioService.GetById(id);
            if (dto == null)
            {
                return NotFound("id not found");
            }
            return Ok(dto);
        }


        [HttpGet("nome")]
        public async Task<ActionResult<UsuarioDTO>> GetByName(string nome)
        {
            var dto = await _usuarioService.GetByName(nome);
            if (dto == null)
            {
                return NotFound("id not found");
            }
            return Ok(dto);
        }

    

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioDTO dto)
        {
            var usuario = await _usuarioService.Create(dto);

            if (usuario == null)
            {
                return BadRequest();
            }
            return Ok(usuario);
        }


        [HttpPost ("cadastro/userComum")]
        public async Task<ActionResult> CriarUsuarioComum([FromBody] UsuarioDTO dto)
        {
            var usuario = await _usuarioService.CreateUserComum(dto);

            if (usuario == null)
            {
                return BadRequest();
            }
            return Ok(usuario);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("cadastro/userAdmin")]
        public async Task<ActionResult> CriarUsuarioAdmin([FromBody] UsuarioDTO dto)
        {
            var usuario = await _usuarioService.CreateUserAdmin(dto);

            if (usuario == null)
            {
                return BadRequest();
            }
            return Ok(usuario);
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] UsuarioDTO dto)
        {
            if (id != dto.IdUsuario)
                return BadRequest();

            if (dto is null)
                return BadRequest();

            await _usuarioService.Update(dto);

            return Ok(dto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<UsuarioDTO>> Delete(int id)
        {
            var dto = await _usuarioService.GetById(id);
            if (dto == null)
            {
                return NotFound("Usuario not found");
            }

            await _usuarioService.Delete(id);

            return Ok(dto);
        }

    }

}
