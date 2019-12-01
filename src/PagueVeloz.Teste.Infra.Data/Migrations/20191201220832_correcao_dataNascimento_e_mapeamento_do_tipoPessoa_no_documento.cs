using Microsoft.EntityFrameworkCore.Migrations;

namespace PagueVeloz.Teste.Infra.Data.Migrations
{
    public partial class correcao_dataNascimento_e_mapeamento_do_tipoPessoa_no_documento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Documento_TipoPessoa",
                table: "Fornecedor",
                newName: "TipoPessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoPessoa",
                table: "Fornecedor",
                newName: "Documento_TipoPessoa");
        }
    }
}
