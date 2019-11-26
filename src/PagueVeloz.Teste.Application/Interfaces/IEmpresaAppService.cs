using System;
using System.Collections.Generic;
using PagueVeloz.Teste.Application.DTOs;
using PagueVeloz.Teste.Application.ViewModels;

namespace PagueVeloz.Teste.Application
{
    public interface IEmpresaAppService
    {
        void Cadastrar(CadastrarEmpresaDto cadastrarEmpresa);
        void VincularFornecedor(CadastrarFornecedorDto cadastrarFornecedorDto);

        ICollection<EmpresaViewModel> Obter();
        ICollection<FornecedorViewModel> ObterFornecedores(Guid idEmpresa);
    }
}