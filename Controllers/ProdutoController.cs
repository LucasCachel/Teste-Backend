using Microsoft.AspNetCore.Mvc;
using MeuProjetoBackend.Services; 
using MeuProjetoBackend.Models; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuProjetoBackend.Controllers
{
    [Route("produto")] 
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        
        [HttpGet] 
        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoService.GetProdutosAsync();
            return View(produtos); 
        }

        
        [HttpGet("Edit/{id}")] 
        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _produtoService.GetProdutoByIdAsync(id);
            if (produto == null)
                return NotFound();
            return View(produto); 
        }

        
        [HttpPost("Edit/{id}")] 
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            if (id != produto.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _produtoService.UpdateProdutoAsync(id, produto);
                return RedirectToAction(nameof(Index)); 
            }
            return View(produto); 
        }

        
        [HttpGet("Create")] 
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost("Create")] 
        public async Task<IActionResult> Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                await _produtoService.CreateProdutoAsync(produto);
                return RedirectToAction(nameof(Index)); 
            }
            return View(produto); 
        }

        
        [HttpGet("Delete/{id}")] 
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _produtoService.GetProdutoByIdAsync(id);
            if (produto == null)
                return NotFound();
            return View(produto); 
        }

        
        [HttpPost("Delete/{id}")] 
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sucesso = await _produtoService.DeleteProdutoAsync(id);
            if (!sucesso)
                return NotFound();
            return RedirectToAction(nameof(Index)); 
        }
    }
}
