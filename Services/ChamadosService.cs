using DeskFlow.Models;
using DeskFlow.Repositories.Interface;
using DeskFlow.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DeskFlow.Services
{
    public class ChamadosService : IChamadosService
    {
        private IChamadosRepository _chamadosRepository;

        public ChamadosService(IChamadosRepository context)
        {
            _chamadosRepository = context;
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

        public async Task Deletar(Chamado chamado)
        {
            await _chamadosRepository.Deletar(chamado);
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