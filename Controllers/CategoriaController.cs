using DeskFlow.Models;
using DeskFlow.Repositories.Interfaces;
using DeskFlow.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace DeskFlow.Controllers
{
    [ApiController]
    [Route("categorias")]
    public class CategoriaController : ControllerBase
    {
        private ICategoriasService _categoriaService;

        public CategoriaController(ICategoriasService categoriasService, ICategoriasRepository categoriasRepository)
        {
            _categoriaService = categoriasService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            List<Categoria> categorias = await _categoriaService.ObterTodosAsync();
            return Ok(categorias);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsync([FromRoute] string id)
        {
            Categoria categoria = await _categoriaService.ObterPorIdAsync(id);
            return Ok(categoria);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            await _categoriaService.Deletar(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> CadastrarAsync([FromBody] Categoria categoria)
        {
            await _categoriaService.CadastrarAsync(categoria);
            return Created("/categorias", categoria);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar([FromBody] Categoria categoriaAtualizada, [FromRoute] string id)
        {
            await _categoriaService.Atualizar(categoriaAtualizada, id);
            return Ok();
        }


    }
}