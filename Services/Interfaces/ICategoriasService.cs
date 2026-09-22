using DeskFlow.Models;

namespace DeskFlow.Services.Interface
{
    public interface ICategoriasService
    {
        Task Deletar(string id);
        Task Atualizar(Categoria categoria, string id);
        Task CadastrarAsync(Categoria categoria);
        Task<Categoria> ObterPorIdAsync(string id);
        Task<List<Categoria>> ObterTodosAsync();
    }
}