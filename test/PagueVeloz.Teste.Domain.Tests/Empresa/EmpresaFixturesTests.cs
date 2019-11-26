using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Bogus;
using Bogus.Extensions.Brazil;
using Xunit;

namespace PagueVeloz.Teste.Domain.Tests
{
    [CollectionDefinition(nameof(EmpresaTestsCollection))]
    public class EmpresaTestsCollection : ICollectionFixture<EmpresaFixturesTests>
    {

    }

    public class EmpresaFixturesTests
    {
        private readonly Faker _faker;

        public EmpresaFixturesTests()
        {
            _faker = new Faker("pt_BR"); ;
        }

        public IEnumerable<Empresa> ObterEmpresaValida(int quantidade = 1)
        {
            var fakerEmpresa = new Faker<Empresa>("pt_BR")
                .CustomInstantiator(f => new Empresa(
                    f.Company.CompanyName(),
                    f.Company.Cnpj(),
                    f.Address.StateAbbr()));

            return fakerEmpresa.Generate(quantidade);
        }

        public IEnumerable<Fornecedor> ObterFornecedorValido(Empresa empresa, int quantidade = 1)
        {
            var docs = new List<string>(2) { _faker.Person.Cpf(), _faker.Company.Cnpj() };

            var faker = new Faker<Fornecedor>()
                .CustomInstantiator(f => new Fornecedor
                    (
                        empresa,
                        f.Person.Company.Name,
                        "5.267.803",
                        f.Person.DateOfBirth,
                        _faker.PickRandom(docs),
                        new Telefone(f.Phone.PhoneNumber())
                ));

            return faker.Generate(quantidade);
        }
    }
}
