using DeskFlow.Models;
using DeskFlow.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DeskFlow.Repositories
{
    public class CategoriaRepository : ICategoriasRepository
    {
        private AppDbContext _context;
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task Atualizar(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task CadastrarAsync(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task Deletar(Categoria categoria)
        {
            throw new NotImplementedException()
        }

        public async Task<Categoria> ObterPorIdAsync(int id)
        {
            return await _context.Categoria.FindAsync(id);
        }

        public async Task<List<Categoria>> ObterTodosAsync()
        {
            return await _context.Categoria.ToListAsync();
        }
    }
}