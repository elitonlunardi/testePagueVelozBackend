using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagueVeloz.Teste.Application;
using PagueVeloz.Teste.Application.DTOs;
using PagueVeloz.Teste.Domain.Core;

namespace PagueVeloz.Teste.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ApiBaseController
    {
        private readonly IFornecedorAppService _fornecedorAppService;
        public FornecedorController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator, IFornecedorAppService fornecedorAppService) : base(notifications, mediator)
        {
            _fornecedorAppService = fornecedorAppService;
        }

        [HttpPost("adicionar-telefone")]
        public IActionResult AdicionarTelefone(AdicionarTelefoneDto dto)
        {
            _fornecedorAppService.AdicionarTelefone(dto);
            return Response();
        }

        [HttpGet("obter-telefones")]
        public IActionResult ObterTelefones(Guid idFornecedor)
        {
            return Response(_fornecedorAppService.ObterTelefones(idFornecedor));
        }
    }
}