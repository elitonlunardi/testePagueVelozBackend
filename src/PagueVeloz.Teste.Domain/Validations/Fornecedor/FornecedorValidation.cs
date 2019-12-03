using FluentValidation;
using PagueVeloz.Teste.Domain.Commands;
using PagueVeloz.Teste.Domain.Commands.Empresa;

namespace PagueVeloz.Teste.Domain.Validations.Fornecedor
{
    public class FornecedorValidation<T> : AbstractValidator<T> where T : FornecedorCommand
    {
        protected void ValidateIdFornecedor()
        {
            RuleFor(f => f.IdFornecedor)
                .NotEmpty()
                .WithMessage("É necessário um Id de um fornecedor para vincular um telefone.");
        }

        protected void ValidateIdEmpresa()
        {
            RuleFor(f => f.IdEmpresa)
                .NotEmpty()
                .WithMessage("É necessário um Id de empresa para efetuar a operação.");
        }

        protected void ValidateNome()
        {
            RuleFor(f => f.Nome)
                .NotEmpty()
                .WithMessage("É necessário um nome para vincular um fornecedor.");

            RuleFor(f => f.Nome)
                .MaximumLength(150)
                .WithMessage("O nome do fornecedor deve ter no máximo 150 caractéres");
        }

        protected void ValidateDocumento()
        {
            RuleFor(f => f.Documento)
                .NotEmpty()
                .WithMessage("É necessário um documento para vincular um fornecedor");
        }

        protected void ValidateTelefone()
        {
            RuleFor(f => f.Telefone)
                .NotEmpty()
                .WithMessage("É necessário um telefone para vincular a um fornecedor");

            RuleFor(f => f.Telefone)
                .MinimumLength(7)
                .WithMessage("É necessário no mínimo 7 números para o telefone");

            RuleFor(f => f.Telefone)
                .MaximumLength(12)
                .WithMessage("É permitido no máximo 10 números para o telefone");
        }

        protected void ValidateRg()
        {
            RuleFor(f => f.Rg.Value)
                .MaximumLength(10)
                .WithMessage("O RG deve ter no máximo 10 caractéres");
        }
    }
}