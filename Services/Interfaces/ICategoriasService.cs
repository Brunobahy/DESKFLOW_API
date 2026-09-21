using DeskFlow.Models;

namespace DeskFlow.Services.Interface
{
    public interface ICategoriasService
    {
        Task<List<Categoria>> ObterTodosAsync();
        Task<Categoria> ObterPorIdAsync(int id);
        Task CadastrarAsync(Categoria categoria);
        Task Deletar(Categoria categoria);
        Task Atualizar(Categoria categoria);
    }
}