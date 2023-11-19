
using Microsoft.AspNetCore.Mvc;
using ResenhaFilmesAPI.DTO;
using ResenhaFilmesAPI.Service.Contracts;
using ResenhaFilmesAPI.Services;
using System.ComponentModel.DataAnnotations;

namespace ResenhaFilmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmistradorController : ControllerBase
    {

        private readonly IAdmistradorService _admistradorService;

        public AdmistradorController(IAdmistradorService admistradorService)
        {
            _admistradorService = admistradorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdministradorDTO>>> GetAll()
        {
            var dtos = await _admistradorService.GetAll();

            if (dtos is null)
                return NotFound("Visitante not found");

            return Ok(dtos);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<AdministradorDTO>> GetById(int id)
        {
            var dto = await _admistradorService.GetById(id);
            if (dto == null)
            {
                return NotFound("id not found");
            }
            return Ok(dto);
        }


        [HttpGet("nome")]
        public async Task<ActionResult<AdministradorDTO>> GetByName([Required]string nome)
        {
            var dto = await _admistradorService.GetByName(nome);
            if (dto == null)
            {
                return NotFound("id not found");
            }
            return Ok(dto);
        }


        [HttpGet("logar")]
        public async Task<ActionResult<AdministradorLoginDTO>> GetByLoginSenha(AdministradorLoginDTO administradorLoginDTO)
        {
            var dto = await _admistradorService.GetByLoginSenha(administradorLoginDTO.Login, administradorLoginDTO.Senha);
            if (dto == null)
            {
                return NotFound("id not found");
            }
            return Ok(dto);
        }

      
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AdministradorDTO dto)
        {
            var administrador = await _admistradorService.Create(dto);

            if (administrador == null)
            {
                return BadRequest();
            }
            return Ok(administrador);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] AdministradorDTO dto)
        {
            if (id != dto.Id)
                return BadRequest();

            if (dto is null)
                return BadRequest();

            await _admistradorService.Update(dto);

            return Ok(dto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AdministradorDTO>> Delete(int id)
        {
            var dto = await _admistradorService.GetById(id);
            if (dto == null)
            {
                return NotFound("Visitante not found");
            }

            await _admistradorService.Delete(id);

            return Ok(dto);
        }
    }
}
