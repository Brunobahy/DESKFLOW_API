using DeskFlow.Models;

namespace DeskFlow.Services.Interface
{

    public interface IChamadosService
    {
        Task<List<Chamado>> ObterTodosAsync();
        Task<Chamado> ObterPorIdAsync(string id);
        Task CadastrarAsync(Chamado chamado);
        Task Deletar(Chamado chamado);
        Task Atualizar(Chamado chamado, string id);
    }
}