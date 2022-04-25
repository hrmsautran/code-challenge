using Xunit;
using FluentAssertions;
using CalculaJurosAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Unit.CalculaJurosAPI.Controllers
{
    public class CalculaJurosControllerTest
    {
        [Fact]
        public void CalculaJuros_DeveRetornarStatusCode200()
        {
            // Arrange
            var controller = new CalculaJurosController();

            // Act
            var result = (OkObjectResult)controller.Get(100, 5);

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData(100, 5, 105.10)]
        [InlineData(90, 8, 97.45)]
        [InlineData(100.40, 3, 103.44)]
        public void CalcularJuros_DeveRetornarValorCalculado (decimal valorInicial, int meses, decimal expected)
        {
            // Arrange
            var controller = new CalculaJurosController();

            // Act
            var result = (OkObjectResult)controller.Get(valorInicial, meses);

            // Assert
            result.Value.Should().Be(expected);
        }
    }
}
