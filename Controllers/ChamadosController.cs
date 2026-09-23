using DeskFlow.Models;
using DeskFlow.Repositories;
using DeskFlow.Repositories.Interfaces;
using DeskFlow.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.NativeInterop;

namespace DeskFlow.Controllers
{
    [ApiController]
    [Route("chamados")]
    public class ChamadosCotroller : ControllerBase
    {
        private IChamadosService _chamadoService;
        public ChamadosCotroller(IChamadosService chamadosService)
        {
            _chamadoService = chamadosService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            List<Chamado> chamados = await _chamadoService.ObterTodosAsync();
            return Ok(chamados);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsync([FromRoute] string id)
        {
            Chamado chamado = await _chamadoService.ObterPorIdAsync(id);
            return Ok(chamado);
        }
        [HttpDelete("{id}")]
        public async Task Deletar([FromRoute] string id)
        {
            await _chamadoService.Deletar(id);
        }
        [HttpPut("{id}")]
        public async Task Atualizar([FromRoute] string id, [FromBody] Chamado chamado)
        {
            await _chamadoService.Atualizar(chamado, id);
        }

        [HttpPost]
        public async Task CadastrarAsync([FromBody] Chamado chamado)
        {
            await _chamadoService.CadastrarAsync(chamado);
        }

        [HttpPost("{id}/iniciar")]
        public async Task IniciarChamado([FromRoute] string id)
        {
            await _chamadoService.Iniciar(id);
        }
        [HttpPost("{id}/finalizar")]
        public async Task FinalizarChamado([FromRoute] string id)
        {
            await _chamadoService.Finalizar(id);
        }
    }
}