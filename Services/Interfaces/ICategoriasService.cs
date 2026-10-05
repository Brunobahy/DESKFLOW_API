using DeskFlow.Models;

namespace DeskFlow.Services.Interfaces
{
    public interface ICategoriasService
    {
        Task Deletar(string id);
        Task<Categoria> Atualizar(Categoria categoria, string id);
        Task<Categoria> CadastrarAsync(Categoria categoria);
        Task<Categoria> ObterPorIdAsync(string id);
        Task<List<Categoria>> ObterTodosAsync();
    }
}