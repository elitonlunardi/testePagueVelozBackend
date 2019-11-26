using System.Linq;
using FluentAssertions;
using PagueVeloz.Teste.Domain.Tests;
using Xunit;

namespace PagueVeloz.Teste.Domain
{
    [Collection(nameof(EmpresaTestsCollection))]
    public class EmpresaTests
    {
        private readonly EmpresaFixturesTests _empresaFixturesTests;
        public EmpresaTests(EmpresaFixturesTests empresaFixturesTests)
        {
            _empresaFixturesTests = empresaFixturesTests;
        }


        [Fact]
        [Trait("Categoria", "Empresa testes")]
        public void Empresa_Criar_DeveExecutarComSucesso()
        {
            //Arrange && Act
            var empresa = _empresaFixturesTests.ObterEmpresaValida().FirstOrDefault();

            //Assert
            empresa.Should().NotBeNull("A empresa gerada é válida");
            empresa.Fornecedores.Should().BeNull("Construtor não espera um fornecedor");
        }

        [Fact]
        [Trait("Categoria", "Empresa testes")]
        public void Empresa_VincularFornecedor_DeveExecutarComSucesso()
        {
            //Arrange
            var empresa = _empresaFixturesTests.ObterEmpresaValida().FirstOrDefault();

            //Act
            empresa.VincularFornecedor(_empresaFixturesTests.ObterFornecedorValido(empresa).FirstOrDefault());

            //Assert
            empresa.Fornecedores.Should().HaveCount(1, " o fornecedor deve ser vinculado com sucesso.");
        }

    }
}