
using System;
using PagueVeloz.Teste.Domain.Validations.Fornecedor;

namespace PagueVeloz.Teste.Domain.Commands
{
    public class VincularFornecedorEmpresaCommand : FornecedorCommand
    {
        public VincularFornecedorEmpresaCommand(Guid idEmpresa, string nome, string rg, DateTime dataNascimento, string documento, string telefone)
        {
            IdEmpresa = idEmpresa;
            Nome = nome;
            Rg = rg;
            DataNascimento = dataNascimento;
            Documento = documento;
            Telefone = telefone;
        }

        public override bool IsValid()
        {
            ValidationResult = new VincularFornecedorEmpresaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}