using FluentValidation;
using PagueVeloz.Teste.Domain.Commands;

namespace PagueVeloz.Teste.Domain.Validations.Fornecedor
{
    public class AdicionarTelefoneFornecedorCommandValidation : FornecedorValidation<AdicionarTelefoneFornecedorCommand>
    {
        public AdicionarTelefoneFornecedorCommandValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            ValidateIdFornecedor();
            ValidateIdEmpresa();
            ValidateTelefone();
        }
    }
}