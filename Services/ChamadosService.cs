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

        public Task Atualizar(Chamado chamado)
        {
            throw new NotImplementedException();
        }

        public Task CadastrarAsync(Chamado chamado)
        {
            throw new NotImplementedException();
        }

        public Task Deletar(Chamado chamado)
        {
            throw new NotImplementedException();
        }

        public Task<Chamado> ObterPorIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Chamado>> ObterTodosAsync()
        {
            List<Chamado> chamados = await _chamadosRepository.ObterTodosAsync();
            return Ok(chamados);
        }
    }
}