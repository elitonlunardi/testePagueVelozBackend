using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PagueVeloz.Teste.Application;
using PagueVeloz.Teste.Application.DTOs;
using PagueVeloz.Teste.Domain.Core;

namespace PagueVeloz.Teste.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ApiBaseController
    {
        private readonly IEmpresaAppService _empresaAppService;

        public EmpresaController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            IEmpresaAppService empresaAppService)
            : base(notifications, mediator)
        {
            _empresaAppService = empresaAppService;
        }


        [HttpPost]
        public IActionResult Post(CadastrarEmpresaDto empresaDto)
        {
            _empresaAppService.Cadastrar(empresaDto);
            return Response();
        }

        [HttpPost("vincular-fornecedor")]
        public IActionResult VincularFornecedor(CadastrarFornecedorDto fornecedorDto)
        {
            _empresaAppService.VincularFornecedor(fornecedorDto);
            return Response();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_empresaAppService.Obter());
        }

        [HttpGet("{idEmpresa}/obter-fornecedores")]
        public IActionResult Get(Guid idEmpresa)
        {
            return Response(_empresaAppService.ObterFornecedores(idEmpresa));
        }
    }
}