using MeuProjetoBackend.Models;
using MeuProjetoBackend.Repositories;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuProjetoBackend.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IValidator<Produto> _produtoValidator;

        public ProdutoService(IProdutoRepository produtoRepository, IValidator<Produto> produtoValidator)
        {
            _produtoRepository = produtoRepository;
            _produtoValidator = produtoValidator;
        }

        public async Task<Produto> CreateProdutoAsync(Produto produto)
        {
            var validationResult = await _produtoValidator.ValidateAsync(produto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            return await _produtoRepository.CreateProdutoAsync(produto);
        }

        public async Task<List<Produto>> GetProdutosAsync()
        {
            return await _produtoRepository.GetProdutosAsync();
        }

        public async Task<Produto?> GetProdutoByIdAsync(int id)
        {
            return await _produtoRepository.GetProdutoByIdAsync(id);
        }

        public async Task<Produto?> UpdateProdutoAsync(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return null;
            }

            var validationResult = await _produtoValidator.ValidateAsync(produto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            return await _produtoRepository.UpdateProdutoAsync(id, produto);
        }

        public async Task<bool> DeleteProdutoAsync(int id)
        {
            var produto = await _produtoRepository.GetProdutoByIdAsync(id);
            if (produto == null)
            {
                return false;
            }
            
            return await _produtoRepository.DeleteProdutoAsync(id);
        }
    }
}
