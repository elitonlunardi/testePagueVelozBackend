using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Bogus;
using Bogus.DataSets;
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
        public IEnumerable<Empresa> ObterEmpresaValida(string uf, int quantidade = 1)
        {
            var fakerEmpresa = new Faker<Empresa>("pt_BR")
                .CustomInstantiator(f => new Empresa(
                    f.Company.CompanyName(),
                    ObterCnpjValido(),
                    uf));

            return fakerEmpresa.Generate(quantidade);
        }
        public IEnumerable<Fornecedor> ObterFornecedorValido(Empresa empresa, string rg,
            int quantidade = 1)
        {

            var faker = new Faker<Fornecedor>()
                .CustomInstantiator(f => new Fornecedor
                (
                    empresa,
                    f.Person.Company.Name,
                    rg,
                    DateTime.Now.AddYears(-20),
                    ObterDocumentoValido(),
                    new Telefone(f.Phone.PhoneNumber())
                ));

            return faker.Generate(quantidade);
        }

        public IEnumerable<Fornecedor> ObterFornecedorParanaValido(Empresa empresa, string rg, int quantidade = 1)
        {
            var faker = new Faker<Fornecedor>()
                .CustomInstantiator(f => new Fornecedor
                (
                    empresa,
                    f.Person.Company.Name,
                    rg,
                    DateTime.Now.AddYears(-20),
                    ObterDocumentoValido(),
                    new Telefone(f.Phone.PhoneNumber())
                ));

            return faker.Generate(quantidade);
        }

        public IEnumerable<Fornecedor> ObterFornecedorParanaInvalido(Empresa empresa, string rg, int quantidade = 1)
        {
            var dataNascimento = _faker.Date.Past(17, DateTime.Now);
            var doc = ObterCpfValido();

            var faker = new Faker<Fornecedor>()
                .CustomInstantiator(f => new Fornecedor
                (
                    empresa,
                    f.Person.Company.Name,
                    rg,
                    dataNascimento,
                    doc,
                    new Telefone(f.Phone.PhoneNumber())
                ));

            return faker.Generate(quantidade);
        }


        private string ObterDocumentoValido()
        {
            var docs = new List<string>(2) { _faker.Person.Cpf(), _faker.Company.Cnpj() };
            return _faker.PickRandom(docs);
        }
        public string ObterCpfValido() => _faker.Person.Cpf();
        public string ObterCnpjValido() => _faker.Company.Cnpj();
    }
}
