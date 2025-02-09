using MeuProjetoBackend.Data;
using MeuProjetoBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuProjetoBackend.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> CreateProdutoAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<List<Produto>> GetProdutosAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto?> GetProdutoByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<Produto?> UpdateProdutoAsync(int id, Produto produto)
        {
            var existingProduto = await _context.Produtos.FindAsync(id);
            if (existingProduto == null) return null;

            existingProduto.Nome = produto.Nome;
            existingProduto.Descricao = produto.Descricao;
            existingProduto.Preco = produto.Preco;

            await _context.SaveChangesAsync();
            return existingProduto;
        }

        public async Task<bool> DeleteProdutoAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) return false;

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return true;
        }

        // Implementar os métodos que estavam faltando
        public async Task<List<Produto>> GetAllAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto?> GetByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<Produto> CreateAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto?> UpdateAsync(Produto produto)
        {
            var existingProduto = await _context.Produtos.FindAsync(produto.Id);
            if (existingProduto == null) return null;

            existingProduto.Nome = produto.Nome;
            existingProduto.Descricao = produto.Descricao;
            existingProduto.Preco = produto.Preco;

            await _context.SaveChangesAsync();
            return existingProduto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) return false;

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
