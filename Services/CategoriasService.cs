
using DeskFlow.Models;
using DeskFlow.Repositories.Interfaces;
using DeskFlow.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DeskFlow.Services
{
    public class CategoriasService : ICategoriasService
    {
        private ICategoriasRepository _categoriasRepository;

        public CategoriasService(ICategoriasRepository categoriasRepository)
        {
            _categoriasRepository = categoriasRepository;
        }

        public async Task Atualizar(Categoria categoriaAtualizada, string id)
        {
            Categoria categoriaDb = await _categoriasRepository.ObterPorIdAsync(id);
            if (categoriaDb != null)
            {
                categoriaDb.Atualizar(categoriaAtualizada);
                await _categoriasRepository.Atualizar(categoriaDb);
            }
        }

        public async Task CadastrarAsync(Categoria categoria)
        {
            List<Categoria> listaCategoria = await _categoriasRepository.ObterTodosAsync();
            bool repetido = false;
            listaCategoria.ForEach(categoriaDb =>
            {
                if (categoriaDb.Nome.ToLower() == categoria.Nome.ToLower())
                {
                    repetido = true;
                    return;
                }
            });
            if (!repetido)
            {
                await _categoriasRepository.CadastrarAsync(categoria);
            }
            return;
        }

        public async Task Deletar(string id)
        {
            Categoria categoriaDB = await _categoriasRepository.ObterPorIdAsync(id);
            if (categoriaDB == null)
            {
                return;
            }
            await _categoriasRepository.Deletar(categoriaDB);


        }

        public async Task<Categoria> ObterPorIdAsync(string id)
        {
            return await _categoriasRepository.ObterPorIdAsync(id);
        }

        public async Task<List<Categoria>> ObterTodosAsync()
        {
            return await _categoriasRepository.ObterTodosAsync();
        }
    }
}