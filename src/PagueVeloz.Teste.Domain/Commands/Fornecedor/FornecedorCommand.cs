﻿using System;
using PagueVeloz.Teste.Domain.Core;

namespace PagueVeloz.Teste.Domain.Commands
{
    public abstract class FornecedorCommand : Command
    {
        public Guid IdFornecedor { get; protected set; }
        public Guid IdEmpresa { get;  protected  set; }
        public string Nome { get; protected set; }
        public Rg Rg { get; protected set; }
        public DataNascimento DataNascimento { get; protected set; }
        public string Documento { get; protected set; }
        public string Telefone { get; protected set; }
    }
}
