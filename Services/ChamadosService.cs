
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
        private ICategoriasRepository _categoriaRepository;

        public ChamadosService(IChamadosRepository chamadosRepository, ICategoriasRepository categoriaRepository)
        {
            _chamadosRepository = chamadosRepository;
            _categoriaRepository = categoriaRepository;
        }

        private async Task<Chamado> ObtemOuErro(string id)
        {
            Chamado chamadoDb = await _chamadosRepository.ObterPorIdAsync(id);
            if (chamadoDb == null)
            {
                throw new NotFoundException("Chamado não econtrado");
            }
            return chamadoDb;
        }

        public async Task Atualizar(Chamado chamado, string id)
        {
            Chamado DbChamado = await ObtemOuErro(id);
            DbChamado.Atualizar(chamado);
            await _chamadosRepository.Atualizar(DbChamado);
        }

        public async Task CadastrarAsync(Chamado chamado)
        {
            Categoria categoria = await _categoriaRepository.ObterPorIdAsync(chamado.CategoriaId);

            if (categoria == null)
            {
                throw new NotFoundException("ID da Categoria não encontrado!");
            }
            chamado.Categoria = categoria;
            Interacao interacao = new Interacao(
                "Sistema",
                $"Chamado aberto dia {DateTime.Now.Day}/{DateTime.Now.Month}"
            );
            interacao.ChamadoId = chamado.Id;
            chamado.Interacoes.Add(interacao);
            await _chamadosRepository.CadastrarAsync(chamado);
        }

        public async Task Deletar(string id)
        {
            Chamado chamadoDb = await ObtemOuErro(id);
            await _chamadosRepository.Deletar(chamadoDb);
        }

        public async Task<Chamado?> ObterPorIdAsync(string id)
        {
            return await ObtemOuErro(id);
        }

        public async Task<List<Chamado>> ObterTodosAsync(string? status, string? prioridade, string? categoriaId)
        {
            List<Chamado> chamados = await _chamadosRepository.ObterTodosAsync(status, prioridade, categoriaId);
            return chamados;
        }
        public async Task Iniciar(string id)
        {
            Chamado chamadoDb = await ObtemOuErro(id);
            chamadoDb.AlterarStatus("EmAndamento");
            await _chamadosRepository.Atualizar(chamadoDb);
        }
        public async Task Finalizar(string id, string solucao)
        {
            Chamado chamadoDb = await ObtemOuErro(id);
            chamadoDb.Solucao = solucao;
            chamadoDb.Finalizar();
            await _chamadosRepository.Atualizar(chamadoDb);
        }

        public async Task<Interacao> AdicionarInteracaoAsync(string id, Interacao interacao)
        {
            Chamado chamadoDb = await ObtemOuErro(id);
            if (chamadoDb.Status == "Fechado")
            {
                throw new ValidationException("Não é possivel interagir com chamados Fechados!");
            }
            interacao.ChamadoId = chamadoDb.Id;
            chamadoDb.AdicionarInteracao(interacao);
            await _chamadosRepository.Atualizar(chamadoDb);
            return interacao;
        }

    }
}