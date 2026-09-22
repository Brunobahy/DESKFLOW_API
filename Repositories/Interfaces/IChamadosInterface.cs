using DeskFlow.Models;

namespace DeskFlow.Repositories.Interfaces
{
    public interface IChamadosRepository
    {
        Task<List<Chamado>> ObterTodosAsync();
        Task<Chamado> ObterPorIdAsync(string id);
        Task CadastrarAsync(Chamado chamado);
        Task Deletar(Chamado chamado);
        Task Atualizar(Chamado chamado);
    }
}