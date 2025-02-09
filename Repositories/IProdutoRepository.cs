using MeuProjetoBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuProjetoBackend.Repositories
{
    public interface IProdutoRepository
    {
        Task<Produto> CreateProdutoAsync(Produto produto);
        Task<List<Produto>> GetProdutosAsync();
        Task<Produto?> GetProdutoByIdAsync(int id);
        Task<Produto?> UpdateProdutoAsync(int id, Produto produto);
        Task<bool> DeleteProdutoAsync(int id);

        
        Task<List<Produto>> GetAllAsync(); 
        Task<Produto?> GetByIdAsync(int id); 
        Task<Produto> CreateAsync(Produto produto); 
        Task<Produto?> UpdateAsync(Produto produto); 
        Task<bool> DeleteAsync(int id); 
    }
}
