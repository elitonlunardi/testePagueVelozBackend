using System;
using System.Collections.Generic;
using PagueVeloz.Teste.Application.DTOs;
using PagueVeloz.Teste.Application.ViewModels;

namespace PagueVeloz.Teste.Application
{
    public interface IFornecedorAppService
    {
        void AdicionarTelefone(AdicionarTelefoneDto dto);
        ICollection<FornecedorViewModel> ObterTelefones(Guid idFornecedor);
    }
}