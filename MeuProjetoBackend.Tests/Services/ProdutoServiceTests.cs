using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using FluentAssertions;
using MeuProjetoBackend.Models;
using MeuProjetoBackend.Services;
using MeuProjetoBackend.Repositories;
using FluentValidation;

namespace MeuProjetoBackend.Tests.Services
{
    public class ProdutoServiceTests
    {
        private readonly Mock<IProdutoRepository> _mockRepository;
        private readonly Mock<IValidator<Produto>> _mockValidator;
        private readonly ProdutoService _produtoService;

        public ProdutoServiceTests()
        {
           
            _mockRepository = new Mock<IProdutoRepository>();

            
            _mockValidator = new Mock<IValidator<Produto>>();

            
            _produtoService = new ProdutoService(_mockRepository.Object, _mockValidator.Object);
        }

        [Fact]
        public async Task GetProdutosAsync_DeveRetornarListaDeProdutos()
        {
            
            var produtosEsperados = new List<Produto>
            {
                new Produto { Id = 1, Nome = "Produto 1", Preco = 10.0M },
                new Produto { Id = 2, Nome = "Produto 2", Preco = 20.0M }
            };

            
            _mockRepository.Setup(repo => repo.GetProdutosAsync()).ReturnsAsync(produtosEsperados);

            
            var resultado = await _produtoService.GetProdutosAsync();

            
            resultado.Should().NotBeNull();
            resultado.Should().HaveCount(2);
            resultado[0].Nome.Should().Be("Produto 1");
        }
    }
}
