using DeskFlow.Models;
using DeskFlow.Repositories.Interfaces;
using DeskFlow.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DeskFlow.Services
{
    public class ChamadosService : IChamadosService
    {
        private IChamadosRepository _chamadosRepository;

        public ChamadosService(IChamadosRepository chamadosRepository)
        {
            _chamadosRepository = chamadosRepository;
        }

        public async Task Atualizar(Chamado chamado, string id)
        {
            Chamado DbChamado = await _chamadosRepository.ObterPorIdAsync(id);
            if (DbChamado != null)
            {
                DbChamado.Atualizar(chamado);
                await _chamadosRepository.Atualizar(DbChamado);
            }
        }

        public async Task CadastrarAsync(Chamado chamado)
        {
            await _chamadosRepository.CadastrarAsync(chamado);
        }

        public async Task Deletar(string id)
        {
            Chamado chamadoDb = await _chamadosRepository.ObterPorIdAsync(id);
            if (chamadoDb != null)
            {
                await _chamadosRepository.Deletar(chamadoDb);

            }
        }

        public async Task<Chamado> ObterPorIdAsync(string id)
        {
            return await _chamadosRepository.ObterPorIdAsync(id);
        }

        public async Task<List<Chamado>> ObterTodosAsync()
        {
            List<Chamado> chamados = await _chamadosRepository.ObterTodosAsync();
            return chamados;
        }
    }
}