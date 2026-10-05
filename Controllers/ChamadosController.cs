using DeskFlow.Models;
using DeskFlow.Repositories;
using DeskFlow.Repositories.Interfaces;
using DeskFlow.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.NativeInterop;

namespace DeskFlow.Controllers
{
    [ApiController]
    [Route("api/chamados")]
    public class ChamadosCotroller : ControllerBase
    {
        private IChamadosService _chamadoService;
        public ChamadosCotroller(IChamadosService chamadosService)
        {
            _chamadoService = chamadosService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync(string? status, string? prioridade, string? categoriaId)
        {
            List<Chamado> chamados = await _chamadoService.ObterTodosAsync(status, prioridade, categoriaId);
            return Ok(chamados);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsync([FromRoute] string id)
        {
            Chamado chamado = await _chamadoService.ObterPorIdAsync(id);
            return Ok(chamado);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar([FromRoute] string id)
        {
            await _chamadoService.Deletar(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar([FromRoute] string id, [FromBody] Chamado chamado)
        {
            Chamado chamadoDb = await _chamadoService.Atualizar(chamado, id);
            return Ok(chamadoDb);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAsync([FromBody] Chamado chamado)
        {
            await _chamadoService.CadastrarAsync(chamado);
            return Created("/chamados", chamado);

        }

        [HttpPost("{id}/iniciar")]
        public async Task<IActionResult> IniciarChamado([FromRoute] string id)
        {
            Chamado chamadodb = await _chamadoService.Iniciar(id);
            return Ok(chamadodb);
        }
        [HttpPost("{id}/encerrar")]
        public async Task<IActionResult> FinalizarChamado([FromRoute] string id, [FromBody] string solucao)
        {
            await _chamadoService.Finalizar(id, solucao);
            return NoContent();
        }

        [HttpPost("{id}/interacoes")]
        public async Task<IActionResult> AdicionarInteracao([FromRoute] string id, [FromBody] Interacao interacao)
        {
            Interacao interacao1 = await _chamadoService.AdicionarInteracaoAsync(id, interacao);
            return Ok(interacao1);
        }
    }
}