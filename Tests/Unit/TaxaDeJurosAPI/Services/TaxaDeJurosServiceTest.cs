using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Moq;
using AutoFixture;
using Moq.Protected;
using System.Threading;
using System;
using CalculaJurosAPI.Services;

namespace Tests.Unit.TaxaDeJurosAPI.Services
{
    public class TaxaDeJurosServiceTest
    {
        [Fact]
        public async Task TaxaDeJurosService_DeveRetornarTaxa()
        {
            // Arrange
            var httpClientFactory = new Mock<IHttpClientFactory>();
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var fixture = new Fixture();

            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("105.10"),
                });

            var client = new HttpClient(mockHttpMessageHandler.Object);
            client.BaseAddress = fixture.Create<Uri>();
            httpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

            // Act  
            var service = new TaxaDeJurosService(httpClientFactory.Object);
            var result = await service.GetAsync();

            // Assert  
            httpClientFactory.Verify(f => f.CreateClient(It.IsAny<string>()), Times.Once);

            result.Should().BeGreaterThan(0);
            result.Should().Be(105.10);
        }

        [Fact]
        public async Task TaxaDeJurosService_DeveInformarQuandoNaoForPossivelConsultarATaxa()
        {
            // Arrange
            var httpClientFactory = new Mock<IHttpClientFactory>();
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var fixture = new Fixture();

            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(fixture.Create<string>())
                });

            var client = new HttpClient(mockHttpMessageHandler.Object);
            client.BaseAddress = fixture.Create<Uri>();
            httpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

            // Act  
            var service = new TaxaDeJurosService(httpClientFactory.Object);


            // Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => service.GetAsync());
        }
    }
}
