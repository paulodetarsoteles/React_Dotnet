using back.src.ProAtividade.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using ProAtividade.Domain.Interfaces.Services;

namespace back.src.ProAtividade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtividadeController : Controller
    {
        private readonly IAtividadeService _atividadeService;
        public AtividadeController(IAtividadeService atividadeService)
        {
            _atividadeService = atividadeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var atividades = await _atividadeService.PegarTodasAtividadesAsync(); 
                if(atividades == null) return NoContent(); 
                return Ok(atividades); 
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}"); 
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var atividade = await _atividadeService.PegarAtividadePorIdAsync(id); 
                if(atividade == null) return NoContent(); 
                return Ok(atividade); 
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}"); 
            }
        }        

        [HttpPost]
        public async Task<IActionResult> Post(Atividade model)
        {
            try
            {
                var atividade = await _atividadeService.AdicionarAtividade(model); 
                if(atividade == null) return NoContent(); 
                return Ok(atividade); 
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}"); 
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Atividade model)
        {
            try
            {
                if(model.Id != id) return StatusCode(StatusCodes.Status409Conflict, "ID diferente da nova atividade"); 
                var atividade = await _atividadeService.AtualizarAtividade(model); 
                if(atividade == null) return NoContent(); 
                return Ok(atividade); 
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}"); 
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var atividade = await _atividadeService.PegarAtividadePorIdAsync(id); 
                if(atividade == null) return NoContent(); 
                if(await _atividadeService.DeletarAtividade(id))
                {
                    return Ok(new { message = "Deletado"}); 
                }
                else
                {
                    return BadRequest("Erro: Não Deletado"); 
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}"); 
            }
        }
    }
}