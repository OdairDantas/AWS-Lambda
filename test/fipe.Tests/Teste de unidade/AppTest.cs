using fipe.Models;
using fipe.Tests.Fixtures;
using Moq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace fipe.Tests.Teste_de_unidade
{
    public class AppTest : IClassFixture<HttpFixture<Fabricante>>
    {
        private readonly HttpFixture<Fabricante> _httpFixture;
        public AppTest(HttpFixture<Fabricante> httpFixture)
        {
            _httpFixture = httpFixture;
        }


        [Fact(DisplayName = "Obter fabricantes de veiculos com sucesso")]
        [Trait("Listar", "Obter")]
        public async Task Obter_Fabricantes_Veiculos_ComSucesso()
        {
            //Arrange
            var httpClientFactory = _httpFixture.HttpClientFactoryFixture(HttpStatusCode.OK, It.IsAny<Fabricante>());
            var appMock = new Mock<App>(httpClientFactory.Object);


            //Act
            var response = await appMock.Object.Run();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Obter fabricantes de veiculos vazia")]
        [Trait("Listar", "Obter")]
        public async Task Obter_Fabricantes_Veiculos_NaoEncontrato()
        {
            //Arrange
            var httpClientFactory = _httpFixture.HttpClientFactoryFixture(HttpStatusCode.NotFound, null);
            var appMock = new Mock<App>(httpClientFactory.Object);


            //Act
            var response = await appMock.Object.Run();

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact(DisplayName = "Obter fabricantes de veiculos com erro")]
        [Trait("Listar", "Obter")]
        public async Task Obter_Fabricantes_Veiculos_ComErro()
        {
            //Arrange
            var httpClientFactory = _httpFixture.HttpClientFactoryFixture(HttpStatusCode.BadRequest, null);
            var appMock = new Mock<App>(httpClientFactory.Object);


            //Act
            var response = await appMock.Object.Run();

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
