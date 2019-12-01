using System;

namespace PagueVeloz.Teste.Application.DTOs
{
    public class AdicionarTelefoneDto
    {
        public Guid IdEmpresa { get; set; }
        public Guid IdFornecedor { get; set; }
        public string Numero { get; set; }
    }
}