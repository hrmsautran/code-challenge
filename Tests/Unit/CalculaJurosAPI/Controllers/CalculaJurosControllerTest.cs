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
            var result = (OkResult)controller.Get();

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public void CalcularJuros_DeveRetornarValorCalculado ()
        {
            // Arrange
            var controller = new CalculaJurosController();

            // Act
            var result = (OkObjectResult)controller.Get();

            // Assert
            var expectedValue = 105.10;
            result.Should().Be(expectedValue);
        }
    }
}
