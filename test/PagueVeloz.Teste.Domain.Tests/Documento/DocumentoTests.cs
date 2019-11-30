using Bogus;
using Bogus.Extensions.Brazil;
using FluentAssertions;
using Xunit;

namespace PagueVeloz.Teste.Domain.Tests
{
    public class DocumentoTests
    {
        private readonly Faker<Documento> _fakerCpf;
        private readonly Faker<Documento> _fakerCnpj;
        public DocumentoTests()
        {
            _fakerCpf = new Faker<Documento>("pt_BR")
                .CustomInstantiator(f => f.Person.Cpf());

            _fakerCnpj = new Faker<Documento>("pt_BR")
                .CustomInstantiator(f => f.Company.Cnpj());
        }

        [Fact(DisplayName = "CPF aleatório deve ser válido")]
        [Trait("Categoria", "CPF")]
        public void Documento_CpfAleatorio_DeveEstarValido()
        {
            // Arrange
            var cpfs = _fakerCpf.Generate(100);

            // Act && Assert
            cpfs.ForEach(cpf =>
            {
                cpf.EhValido.Should().BeTrue("os cpfs são válidos");
            });
        }

        [Theory(DisplayName = "CPF aleatório deve ser inválido")]
        [Trait("Categoria", "CPF")]
        [InlineData("278.174.173-42")]
        [InlineData("587.341.988-50")]
        [InlineData("803.686.172-36")]
        [InlineData("652.738.166-07")]
        [InlineData("555.567.571-02")]
        [InlineData("044.125.683-80")]
        public void Documento_CpfAleatorio_DeveEstarInvalido(string cpf)
        {
            // Arrange
            Documento doc = cpf;
            // Act && Assert
            doc.EhValido.Should().BeFalse("o cpf é inválido");
        }


        [Fact(DisplayName = "CNPJ aleatório deve ser válido")]
        [Trait("Categoria", "CNPJ")]
        public void Documento_CnpjAleatorio_DeveEstarValido()
        {
            // Arrange
            var cnpjs = _fakerCnpj.Generate(100);

            // Act && Assert
            cnpjs.ForEach(cpf =>
            {
                cpf.EhValido.Should().BeTrue("os cnpjs são válidos");
            });
        }

        [Theory(DisplayName = "CNPJ aleatório deve ser inválido")]
        [Trait("Categoria", "CNPJ")]
        [InlineData("59.886.416/0001-74")]
        [InlineData("77.223.578/0001-83")]
        [InlineData("12.131.976/0001-94")]
        [InlineData("84.546.829/0001-08")]
        [InlineData("04.516.829/0001-06")]
        [InlineData("14.526.829/0001-05")]
        [InlineData("03.686.808/0001-13")]
        [InlineData("55.148.073/0001-42")]
        [InlineData("95.329.256/0001-61")]
        [InlineData("13.152.416/0001-00")]
        public void Documento_CnpjAleatorio_DeveEstarInvalido(string cnpj)
        {
            // Arrange
            Documento doc = cnpj;
            // Act && Assert
            doc.EhValido.Should().BeFalse("o cnpj deve ser inválido");
        }
    }
}
