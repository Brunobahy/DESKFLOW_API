
using DeskFlow.Exceptions;
using DeskFlow.Models;
using DeskFlow.Repositories.Interfaces;
using DeskFlow.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Identity.Client.NativeInterop;

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
            if (DbChamado == null)
            {
                throw new NotFoundException("Chamado não econtrado");
            }
            DbChamado.Atualizar(chamado);
            await _chamadosRepository.Atualizar(DbChamado);
        }

        public async Task CadastrarAsync(Chamado chamado)
        {
            await _chamadosRepository.CadastrarAsync(chamado);
        }

        public async Task Deletar(string id)
        {
            Chamado chamadoDb = await _chamadosRepository.ObterPorIdAsync(id);
            if (chamadoDb == null)
            {
                throw new NotFoundException("Chamado não encontrado");
            }
            await _chamadosRepository.Deletar(chamadoDb);
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
        public async Task Iniciar(string id)
        {
            Chamado chamadoDb = await _chamadosRepository.ObterPorIdAsync(id);
            if (chamadoDb == null)
            {
                throw new NotFoundException("Chamado não econtrado");
            }
            chamadoDb.AlterarStatus("EmAndamento");
            await _chamadosRepository.Atualizar(chamadoDb);
        }
        public async Task Finalizar(string id)
        {
            Chamado chamadoDb = await _chamadosRepository.ObterPorIdAsync(id);
            if (chamadoDb == null)
            {
                throw new NotFoundException("Chamado não econtrado");
            }
            chamadoDb.Finalizar();
            await _chamadosRepository.Atualizar(chamadoDb);
        }

        public async Task Interacao(string id, Interacao interacao)
        {
            Chamado chamadoDb = await _chamadosRepository.ObterPorIdAsync(id);
            if (chamadoDb == null)
            {
                throw new NotFoundException("Chamado não econtrado");
            }
            chamadoDb.AdicionarInteracao(interacao);
            await _chamadosRepository.Atualizar(chamadoDb);
        }
    }
}