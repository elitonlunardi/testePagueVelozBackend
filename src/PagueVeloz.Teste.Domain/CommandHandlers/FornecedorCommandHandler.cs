using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PagueVeloz.Teste.Domain.CommandHandlers;
using PagueVeloz.Teste.Domain.Commands;
using PagueVeloz.Teste.Domain.Core;
using PagueVeloz.Teste.Domain.Interfaces;

namespace PagueVeloz.Teste.Domain
{
    public class FornecedorCommandHandler : CommandHandler,
        IRequestHandler<VincularFornecedorEmpresaCommand, bool>,
        IRequestHandler<AdicionarTelefoneFornecedorCommand, bool>
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMediatorHandler _mediator;

        public FornecedorCommandHandler(IUnitOfWork uow,
            IMediatorHandler mediator,
            INotificationHandler<DomainNotification> notifications, IEmpresaRepository empresaRepository)
            : base(uow, mediator, notifications)
        {
            _empresaRepository = empresaRepository;
            _mediator = mediator;
        }

        public Task<bool> Handle(VincularFornecedorEmpresaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    NotifyValidationErrors(request);
                    return Task.FromResult(false);
                }

                var empresa = _empresaRepository.GetByIdIncludeFornecedor(request.IdEmpresa);
                empresa.VincularFornecedor(new Fornecedor(empresa, request.Nome, request.Rg, request.DataNascimento, request.Documento, new Telefone(request.Telefone)));

                return Task.FromResult(Commit());
            }
            catch (Exception ex)
            {
                _mediator.AddDomainNotification(request.MessageType, ex.Message);
                return Task.FromResult(false);
            }
        }

        public Task<bool> Handle(AdicionarTelefoneFornecedorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    NotifyValidationErrors(request);
                    return Task.FromResult(false);
                }

                var fornecedor = _empresaRepository.GetByIdIncludeFornecedor(request.IdEmpresa)
                    .Fornecedores
                    .FirstOrDefault(forn => forn.Id.Equals(request.IdFornecedor));

                if (fornecedor == null)
                {
                    _mediator.AddDomainNotification(request.MessageType, "Não foi possível encontrar o fornecedor.");
                    return Task.FromResult(false);
                }

                fornecedor.AdicionarTelefone(new Telefone(request.Telefone));
                return Task.FromResult(Commit());
            }
            catch (Exception ex)
            {
                _mediator.AddDomainNotification(request.MessageType, ex.Message);
                return Task.FromResult(false);
            }
        }
    }
}