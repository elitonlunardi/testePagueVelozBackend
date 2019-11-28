using FluentValidation;
using PagueVeloz.Teste.Domain.Commands;

namespace PagueVeloz.Teste.Domain.Validations.Fornecedor
{
    public class VincularFornecedorEmpresaCommandValidation : FornecedorValidation<VincularFornecedorEmpresaCommand>
    {
        public VincularFornecedorEmpresaCommandValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            ValidateNome();
            ValidateDocumento();
            ValidateTelefone();
            ValidateIdEmpresa();
        }
    }
}