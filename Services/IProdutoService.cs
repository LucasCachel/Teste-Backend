using MeuProjetoBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuProjetoBackend.Services
{
    public interface IProdutoService
    {
        Task<Produto> CreateProdutoAsync(Produto produto);
        Task<List<Produto>> GetProdutosAsync();
        Task<Produto?> GetProdutoByIdAsync(int id);
        Task<Produto?> UpdateProdutoAsync(int id, Produto produto);
        Task<bool> DeleteProdutoAsync(int id);
    }
}
