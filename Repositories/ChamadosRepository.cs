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

        public async Task<Chamado?> ObterPorIdAsync(string id)
        {
            return await _context.Chamado.Include(c => c.Interacoes.OrderBy(d => d.DataRegistro)).Include(c => c.Categoria).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Chamado>> ObterTodosAsync(string? status, string? prioridade, string? categoriaId)
        {
            var query = _context.Chamado.AsQueryable();
            if (status != null)
            {
                query = query.Where(c => c.Status == status);
            }
            if (prioridade != null)
            {
                query = query.Where(c => c.Prioridade == prioridade);
            }
            if (categoriaId != null)
            {
                query = query.Where(c => c.CategoriaId == categoriaId);
            }
            List<Chamado> chamados = await query.ToListAsync();
            return chamados;
        }

        // public async Task<Interacao> AdicionaInteracaoAsync(string id, Interacao interacao)
        // {
        //     List<Chamado> chamados = await _context.Chamado.ToListAsync();

        // }
    }
}