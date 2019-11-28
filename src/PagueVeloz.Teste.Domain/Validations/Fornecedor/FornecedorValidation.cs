using FluentValidation;
using PagueVeloz.Teste.Domain.Commands;
using PagueVeloz.Teste.Domain.Commands.Empresa;

namespace PagueVeloz.Teste.Domain.Validations.Fornecedor
{
    public class FornecedorValidation<T> : AbstractValidator<T> where T : FornecedorCommand
    {
        protected void ValidateIdEmpresa()
        {
            RuleFor(f => f.IdEmpresa)
                .NotEmpty()
                .WithMessage("É necessário um Id de empresa para efetuar a vinculação de um fornecedor.");
        }

        protected void ValidateNome()
        {
            RuleFor(f => f.Nome)
                .NotEmpty()
                .WithMessage("É necessário um nome para vincular um fornecedor.");
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
                .WithMessage("É necessário um telefone para vincular um fornecedor");
        }
    }
}