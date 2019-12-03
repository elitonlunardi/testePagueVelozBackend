using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using PagueVeloz.Teste.Domain;
using PagueVeloz.Teste.Domain.Commands.Empresa;
using PagueVeloz.Teste.Domain.Interfaces;
using PagueVeloz.Teste.Domain.Tests;
using Xunit;

namespace PagueVeloz.Teste.Application.Tests
{
    [Collection(nameof(EmpresaTestsCollection))]
    public class EmpresaCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly EmpresaCommandHandler _empresaCommandHandler;
        private readonly EmpresaFixturesTests _empresaFixturesTests;
        public EmpresaCommandHandlerTests(EmpresaFixturesTests empresaFixturesTests)
        {
            _empresaFixturesTests = empresaFixturesTests;
            _mocker = new AutoMocker();
            _empresaCommandHandler = _mocker.CreateInstance<EmpresaCommandHandler>();
        }

        [Fact(DisplayName = "Cadastro de empresa")]
        [Trait("Categoria", "EmpresaCommandHandlerTests")]
        public async Task Empresa_Cadastar_DeveExecutarComSucesso()
        {
            //Arrange
            var cadastrarEmpresaCommand =
                new CadastrarEmpresaCommand("Éliton Lunardi ME", _empresaFixturesTests.ObterCnpjValido(), "PR");

            //Act
            var result = await _empresaCommandHandler.Handle(cadastrarEmpresaCommand, CancellationToken.None);

            //Assert
            result.Should().BeTrue("command handler deve executar com sucesso");
            _mocker.GetMock<IEmpresaRepository>().Verify(r => r.Add(It.IsAny<Empresa>()), Times.Once);
        }
    }
}
