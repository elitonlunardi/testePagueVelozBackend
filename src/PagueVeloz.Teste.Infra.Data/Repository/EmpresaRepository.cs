using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PagueVeloz.Teste.Domain;
using PagueVeloz.Teste.Domain.Interfaces;

namespace PagueVeloz.Teste.Infra.Data
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(PagueVelozContext context) : base(context)
        { }

        public Empresa GetByIdIncludeFornecedor(Guid id) =>
            Set.Where(emp => emp.Id == id).Include(x => x.Fornecedores).FirstOrDefault();

        public ICollection<Empresa> Obter() =>
            Set.AsNoTracking().ToList();

        public Fornecedor GetByIdFornecedor(Guid idFornecedor)
        {
            var empresas = Set.AsNoTracking().Include(x => x.Fornecedores).ThenInclude(w => w.Telefones);
            foreach (var empresa in empresas)
            {
                foreach (var fornecedor in empresa.Fornecedores)
                {
                    if (fornecedor.Id == idFornecedor)
                        return fornecedor;
                }
            }
            return null;
        }


    }
}