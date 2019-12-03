using System;
using System.Linq;
using FluentAssertions;
using PagueVeloz.Teste.Domain.Exceptions;
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


        [Fact(DisplayName = "Criação de empresa deve executar com sucesso")]
        [Trait("Categoria", "Empresa testes")]
        public void Empresa_Criar_DeveExecutarComSucesso()
        {
            //Arrange && Act
            var empresa = _empresaFixturesTests.ObterEmpresaValida().FirstOrDefault();

            //Assert
            empresa.Should().NotBeNull("A empresa gerada é válida");
            empresa.Fornecedores.Should().BeNull("Construtor não espera um fornecedor");
        }

        [Fact(DisplayName = "Vinculação de fornecedor deve executar com sucesso")]
        [Trait("Categoria", "Empresa testes")]
        public void Empresa_VincularFornecedor_DeveExecutarComSucesso()
        {
            //Arrange
            var empresa = _empresaFixturesTests.ObterEmpresaValida().FirstOrDefault();

            //Act
            empresa.VincularFornecedor(_empresaFixturesTests.ObterFornecedorValido(empresa, "5123213").FirstOrDefault());

            //Assert
            empresa.Fornecedores.Should().HaveCount(1, " o fornecedor deve ser vinculado com sucesso.");
        }

        [Fact(DisplayName = "Vinculação de fornecedor do paraná menor de idade deve falhar")]
        [Trait("Categoria", "Empresa testes")]
        public void Empresa_VincularFornecedorParanaMenorIdade_DeveFalhar()
        {
            //Arrange 
            var empresa = _empresaFixturesTests.ObterEmpresaValida("PR").FirstOrDefault();
            var fornecedor = _empresaFixturesTests.ObterFornecedorParanaInvalido(empresa, "5.726.803").FirstOrDefault();

            //Act & Assert 
            empresa.Invoking(emp => emp.VincularFornecedor(fornecedor))
                .Should().Throw<DomainException>(
                    " a empresa do paraná que o fornecedor é pessoa física deve ser maior de idade");
        }

        [Fact(DisplayName = "Vinculação de fornecedor do paraná maior de idade deve executar com sucesso")]
        [Trait("Categoria", "Empresa testes")]
        public void Empresa_VincularFornecedorParanaMaiorIdade_DeveExecutarSucesso()
        {
            //Arrange 
            var empresa = _empresaFixturesTests.ObterEmpresaValida("PR").FirstOrDefault();
            var fornecedor = _empresaFixturesTests.ObterFornecedorValido(empresa, "5.726.803").FirstOrDefault();

            //Act
            empresa.VincularFornecedor(fornecedor);

            //Assert
            empresa.Fornecedores
                .Should().HaveCount(1, "o fornecedor é válido");
        }

    }
}