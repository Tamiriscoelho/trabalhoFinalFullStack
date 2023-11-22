using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResenhaFilmesAPI.DTO;
using ResenhaFilmesAPI.Service.Contracts;
using ResenhaFilmesAPI.Services;

namespace ResenhaFilmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "comun")]
    public class ResenhaController : ControllerBase
    {
        private readonly IResenhaService _resenhaService;

        public ResenhaController(IResenhaService resenhaService)
        {
            _resenhaService = resenhaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResenhaDTO>>> GetAll()
        {
            var dtos = await _resenhaService.GetAll();

            if (dtos is null)
                return NotFound("Resenha not found");

            return Ok(dtos);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<ResenhaDTO>> GetById(int id)
        {
            var dto = await _resenhaService.GetById(id);
            if (dto == null)
            {
                return NotFound("id not found");
            }
            return Ok(dto);
        }


        [HttpGet("nota")]
        public async Task<ActionResult<IEnumerable<ResenhaDTO>>> GetByNota(int nota)
        {
            var dto = await _resenhaService.GetByNota(nota);

            if (dto == null)
            {
                return NotFound("nota not found");
            }
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ResenhaDTO dto)
        {
            var resenha = await _resenhaService.Create(dto);

            if (resenha == null)
            {
                return BadRequest();
            }
            return Ok(resenha);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ResenhaDTO dto)
        {
            if (id != dto.Id)
                return BadRequest();

            if (dto is null)
                return BadRequest();

            await _resenhaService.Update(dto);

            return Ok(dto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ResenhaDTO>> Delete(int id)
        {
            var dto = await _resenhaService.GetById(id);
            if (dto == null)
            {
                return NotFound("Visitante not found");
            }

            await _resenhaService.Delete(id);

            return Ok(dto);
        }

    }
}
