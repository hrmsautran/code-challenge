using Xunit;
using FluentAssertions;
using CalculaJurosAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using CalculaJurosAPI.Services;
using Moq;
using System.Threading.Tasks;

namespace Tests.Unit.CalculaJurosAPI.Controllers
{
    public class CalculaJurosControllerTest
    {
        [Theory]
        [InlineData(100, 5, 105.10)]
        public async Task CalcularJuros_DeveRetornarValorCalculado(decimal valorInicial, int meses, decimal expected)
        {
            // Arrange
            var mockService = new Mock<ITaxaDeJurosService>();

            mockService
                .Setup(service => service.GetAsync())
                .ReturnsAsync(0.01);

            var controller = new CalculaJurosController(mockService.Object);

            // Act
            var contentResult = await controller.Get(valorInicial, meses);

            var result = ((OkObjectResult)contentResult).Value;

            // Assert
            result.Should().Be(expected);
        }
    }
}
