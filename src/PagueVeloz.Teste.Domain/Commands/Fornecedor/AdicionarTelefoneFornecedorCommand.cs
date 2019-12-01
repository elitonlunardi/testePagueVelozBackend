using System;
using PagueVeloz.Teste.Domain.Validations.Fornecedor;

namespace PagueVeloz.Teste.Domain.Commands
{
    public class AdicionarTelefoneFornecedorCommand : FornecedorCommand
    {
        public AdicionarTelefoneFornecedorCommand(Guid idEmpresa, Guid idFornecedor, string telefone)
        {
            IdFornecedor = idFornecedor;
            IdEmpresa = idEmpresa;
            Telefone = telefone;
        }

        public override bool IsValid()
        {
            ValidationResult = new AdicionarTelefoneFornecedorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}