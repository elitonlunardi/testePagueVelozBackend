using System;
using PagueVeloz.Teste.Application.DTOs;
using PagueVeloz.Teste.Domain.Commands;
using PagueVeloz.Teste.Domain.Core;

namespace PagueVeloz.Teste.Application
{
    public class FornecedorAppService : IFornecedorAppService
    {
        private readonly IMediatorHandler _mediator;

        public FornecedorAppService(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        public void AdicionarTelefone(AdicionarTelefoneDto dto)
        {
            _mediator.SendCommand(new AdicionarTelefoneFornecedorCommand(dto.IdEmpresa, dto.IdFornecedor, dto.Numero));
        }
    }
}