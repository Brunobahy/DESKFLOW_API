
using DeskFlow.Exceptions;
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

        private async Task<Categoria> ObtemOuErro(string id)
        {
            Categoria categoria = await _categoriasRepository.ObterPorIdAsync(id);
            if (categoria == null)
            {
                throw new NotFoundException("Categoria não encontrada!");
            }
            else
            {
                return categoria;
            }
        }


        public async Task<Categoria> Atualizar(Categoria categoriaAtualizada, string id)
        {
            Categoria categoria = await ObtemOuErro(id);

            categoria.Atualizar(categoriaAtualizada);
            await _categoriasRepository.Atualizar(categoria);
            return categoria;
        }

        public async Task<Categoria> CadastrarAsync(Categoria categoria)
        {
            List<Categoria> listaCategoria = await _categoriasRepository.ObterTodosAsync();
            bool repetido = false;
            string categoriaDbId = "";
            listaCategoria.ForEach(categoriaDb =>
            {
                if (categoriaDb.Nome.ToLower() == categoria.Nome.ToLower())
                {
                    repetido = true;
                    categoriaDbId = categoriaDb.Id;
                    return;
                }
            });
            if (repetido)
            {
                throw new ConflictException($"Já existe uma Categoria {categoria.Nome} registrada! Tente acessar pelo Id: {categoriaDbId}");
            }
            else
            {
                await _categoriasRepository.CadastrarAsync(categoria);
            }
            return categoria;
        }

        public async Task Deletar(string id)
        {
            Categoria categoria = await ObtemOuErro(id);

            bool possuiChamados = await _categoriasRepository.PossuiChamadosAsync(id);

            if (possuiChamados)
            {
                throw new ConflictException(
                    "Não é possível excluir a categoria, pois existem chamados associados a ela."
                );
            }

            await _categoriasRepository.Deletar(categoria);
        }

        public async Task<Categoria> ObterPorIdAsync(string id)
        {
            return await ObtemOuErro(id);
        }

        public async Task<List<Categoria>> ObterTodosAsync()
        {
            return await _categoriasRepository.ObterTodosAsync();
        }
    }
}