using DeskFlow.Models;

namespace DeskFlow.Services.Interfaces
{

    public interface IChamadosService
    {
        Task<List<Chamado>> ObterTodosAsync();
        Task<Chamado> ObterPorIdAsync(string id);
        Task CadastrarAsync(Chamado chamado);
        Task Deletar(string id);
        Task Atualizar(Chamado chamado, string id);
        Task Iniciar(string id);
        Task Finalizar(string id);
        Task Interacao(string id, Interacao interacao);
    }
}