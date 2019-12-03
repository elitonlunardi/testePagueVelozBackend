using System;
using System.Collections.Generic;
using System.Linq;
using PagueVeloz.Teste.Application.DTOs;
using PagueVeloz.Teste.Application.ViewModels;
using PagueVeloz.Teste.Domain.Commands;
using PagueVeloz.Teste.Domain.Core;
using PagueVeloz.Teste.Domain.Interfaces;

namespace PagueVeloz.Teste.Application
{
    public class FornecedorAppService : IFornecedorAppService
    {
        private readonly IMediatorHandler _mediator;
        private readonly IEmpresaRepository _empresaRepository;

        public FornecedorAppService(IMediatorHandler mediator, IEmpresaRepository empresaRepository)
        {
            _mediator = mediator;
            _empresaRepository = empresaRepository;
        }

        public void AdicionarTelefone(AdicionarTelefoneDto dto)
        {
            _mediator.SendCommand(new AdicionarTelefoneFornecedorCommand(dto.IdEmpresa, dto.IdFornecedor, dto.Numero));
        }

        public ICollection<FornecedorViewModel> ObterTelefones(Guid idFornecedor)
        {
            var telefones = _empresaRepository
                .GetByIdFornecedor(idFornecedor)?.Telefones;

            var telefoneModel = telefones?.Select(forn => new FornecedorViewModel
            {
                Id = forn.Id,
                Telefone = forn.Numero
            }).ToList();

            return telefoneModel;
        }
    }
}