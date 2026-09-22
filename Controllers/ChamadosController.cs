using DeskFlow.Models;
using DeskFlow.Repositories;
using DeskFlow.Repositories.Interfaces;
using DeskFlow.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task CadastrarAsync([FromBody] Chamado chamado)
        {
            await _chamadoService.CadastrarAsync(chamado);
        }



    }
}