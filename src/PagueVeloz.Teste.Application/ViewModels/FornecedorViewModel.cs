using System;
using PagueVeloz.Teste.Domain;

namespace PagueVeloz.Teste.Application.ViewModels
{
    public class FornecedorViewModel
    {
        public Guid Id { get; set; }
        public Guid IdEmpresa { get; set; }
        public string Nome { get; set; }
        public Documento Documento { get; set; }
    }
}