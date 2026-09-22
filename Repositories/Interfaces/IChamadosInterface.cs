using DeskFlow.Models;

namespace DeskFlow.Repositories.Interface
{
    public interface IChamdosRepository
    {
        Task<List<Chamado>> ObterTodosAsync();
        Task<Chamado> ObterPorIdAsync(string id);
        Task CadastrarAsync(Chamado chamado);
        Task Deletar(Chamado chamado);
        Task Atualizar(Chamado chamado);
    }
}