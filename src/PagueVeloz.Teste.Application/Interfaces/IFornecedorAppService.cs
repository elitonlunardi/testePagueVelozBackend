using System;
using PagueVeloz.Teste.Application.DTOs;

namespace PagueVeloz.Teste.Application
{
    public interface IFornecedorAppService
    {
        void AdicionarTelefone(AdicionarTelefoneDto dto);
    }
}