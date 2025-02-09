using FluentValidation;
using MeuProjetoBackend.Models;

namespace MeuProjetoBackend.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O nome do produto não pode ser vazio.")
                .Length(3, 100).WithMessage("O nome do produto deve ter entre 3 e 100 caracteres.");

            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("A descrição do produto não pode ser vazia.")
                .Length(10, 500).WithMessage("A descrição do produto deve ter entre 10 e 500 caracteres.");

            RuleFor(p => p.Preco)
                .GreaterThan(0).WithMessage("O preço do produto deve ser maior que zero.");
        }
    }
}
