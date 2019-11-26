using System;
using System.Collections.Generic;

namespace PagueVeloz.Teste.Application.ViewModels
{
    public class EmpresaViewModel
    {
        public Guid Id { get; set; }
        public string Cnpj { get; set; }
        public string NomeFantasia { get; set; }
        public string Uf { get; set; }

        public ICollection<FornecedorViewModel> Fornecedores { get; set; }

        public EmpresaViewModel()
        {
            Fornecedores = new List<FornecedorViewModel>();
        }
    }
}