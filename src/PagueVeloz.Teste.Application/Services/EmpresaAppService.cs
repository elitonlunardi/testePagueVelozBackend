using System;
using System.Collections.Generic;
using System.Linq;
using PagueVeloz.Teste.Application.DTOs;
using PagueVeloz.Teste.Application.ViewModels;
using PagueVeloz.Teste.Domain.Commands;
using PagueVeloz.Teste.Domain.Commands.Empresa;
using PagueVeloz.Teste.Domain.Core;
using PagueVeloz.Teste.Domain.Interfaces;

namespace PagueVeloz.Teste.Application
{
    public class EmpresaAppService : IEmpresaAppService
    {
        private readonly IMediatorHandler _mediator;
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaAppService(IMediatorHandler mediator, IEmpresaRepository empresaRepository)
        {
            _mediator = mediator;
            _empresaRepository = empresaRepository;
        }

        public void Cadastrar(CadastrarEmpresaDto cadastrarEmpresa)
        {
            _mediator.SendCommand(
                new CadastrarEmpresaCommand(cadastrarEmpresa.NomeFantasia, cadastrarEmpresa.Cnpj, cadastrarEmpresa.Uf));
        }

        public void VincularFornecedor(CadastrarFornecedorDto cadastrarFornecedorDto)
        {
            _mediator.SendCommand(
                new VincularFornecedorEmpresaCommand(cadastrarFornecedorDto.IdEmpresa,
                cadastrarFornecedorDto.Nome,
                cadastrarFornecedorDto.Rg, cadastrarFornecedorDto.DataNascimento, cadastrarFornecedorDto.Documento,
                cadastrarFornecedorDto.Telefone));
        }

        public ICollection<EmpresaViewModel> Obter()
        {
            return _empresaRepository.Obter().Select(emp => new EmpresaViewModel
            {
                Id = emp.Id,
                Cnpj = emp.Cnpj.ToString(),
                NomeFantasia = emp.NomeFantasia,
                Uf = emp.Uf
            }).ToList();
        }

        public ICollection<FornecedorViewModel> ObterFornecedores(Guid idEmpresa)
        {
            return _empresaRepository.GetByIdIncludeFornecedor(idEmpresa)
                .Fornecedores
                .Select(forn =>
                new FornecedorViewModel
                {
                    Documento = forn.Documento,
                    Id = forn.Id,
                    IdEmpresa = forn.IdEmpresa,
                    Nome = forn.Nome
                }).ToList();
        }
    }
}