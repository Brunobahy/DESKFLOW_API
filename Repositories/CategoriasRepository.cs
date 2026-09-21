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
        public async Task Atualizar(Categoria categoria)
        {
            _context.Categoria.Update(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task CadastrarAsync(Categoria categoria)
        {
            await _context.Categoria.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(Categoria categoria)
        {
            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();
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