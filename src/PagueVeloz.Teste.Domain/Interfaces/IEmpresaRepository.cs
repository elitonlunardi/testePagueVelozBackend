using System;
using System.Collections.Generic;

namespace PagueVeloz.Teste.Domain.Interfaces
{
    public interface IEmpresaRepository : IRepository<Empresa>
    {
        Empresa GetByIdIncludeFornecedor(Guid id);
        ICollection<Empresa> Obter();
        Fornecedor GetByIdFornecedor(Guid idFornecedor);
    }
}