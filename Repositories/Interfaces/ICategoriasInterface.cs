using DeskFlow.Models;

namespace DeskFlow.Repositories.Interface
{
    public interface ICategoriasRepository
    {
        Task<List<Categoria>> ObterTodosAsync();
        Task<Categoria> ObterPorIdAsync(string id);
        Task CadastrarAsync(Categoria categoria);
        Task Deletar(Categoria categoria);
        Task Atualizar(Categoria categoria);
    }
}