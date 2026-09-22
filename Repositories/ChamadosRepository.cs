using DeskFlow.Models;
using DeskFlow.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeskFlow.Repositories
{
    public class ChamadosRepository : IChamadosRepository
    {
        private DeskFlowDbContext _context;

        public ChamadosRepository(DeskFlowDbContext context)
        {
            _context = context;
        }

        public async Task Atualizar(Chamado chamado)
        {
            _context.Chamado.Update(chamado);
            await _context.SaveChangesAsync();
        }

        public async Task CadastrarAsync(Chamado chamado)
        {
            await _context.Chamado.AddAsync(chamado);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(Chamado chamado)
        {
            _context.Chamado.Remove(chamado);
            await _context.SaveChangesAsync();
        }

        public async Task<Chamado> ObterPorIdAsync(string id)
        {
            return await _context.Chamado.FindAsync(id);
        }

        public async Task<List<Chamado>> ObterTodosAsync()
        {
            List<Chamado> chamados = await _context.Chamado.ToListAsync();
            return chamados;
        }
    }
}