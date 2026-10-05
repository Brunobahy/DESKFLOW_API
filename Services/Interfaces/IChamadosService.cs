using DeskFlow.Models;

namespace DeskFlow.Services.Interfaces
{

    public interface IChamadosService
    {
        Task<List<Chamado>> ObterTodosAsync(string? status, string? prioridade, string? categoriaId);
        Task<Chamado?> ObterPorIdAsync(string id);
        Task CadastrarAsync(Chamado chamado);
        Task Deletar(string id);
        Task<Chamado> Atualizar(Chamado chamado, string id);
        Task<Chamado> Iniciar(string id);
        Task<Chamado> Finalizar(string id, string solucao);
        Task<Interacao> AdicionarInteracaoAsync(string id, Interacao interacao);
    }
}