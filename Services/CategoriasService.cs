
using DeskFlow.Models;
using DeskFlow.Repositories.Interface;
using DeskFlow.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlow.Services
{
    public class CategoriasService : ICategoriasService
    {
        private ICategoriasRepository _categoriasRepository;

        public CategoriasService(ICategoriasRepository categoriasRepository)
        {
            _categoriasRepository = categoriasRepository;
        }

        public async Task<Categoria> Atualizar(Categoria categoriaAtualizada, int id)
        {
            Categoria categoria = await _categoriasRepository.ObterPorIdAsync(id);
            if (categoria == null)
            {
                return null;
            }
            await _categoriasRepository.Atualizar(categoriaAtualizada);
        }

        public Task CadastrarAsync(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public async Task Deletar(int id)
        {
            Categoria categoriaDB = await _categoriasRepository.ObterPorIdAsync(id);
            if (categoriaDB == null)
            {
                return;
            }
            await _categoriasRepository.Deletar(categoriaDB);


        }

        public async Task<Categoria> ObterPorIdAsync(int id)
        {
            return await _categoriasRepository.ObterPorIdAsync(id);
        }

        public async Task<List<Categoria>> ObterTodosAsync()
        {
            return await _categoriasRepository.ObterTodosAsync();
        }
    }
}