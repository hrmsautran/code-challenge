using Xunit;
using FluentAssertions;
using TaxaDeJurosAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Unit.TaxaDeJurosAPI.Controllers
{
    public class TaxaDeJurosControllerTest
    {
        [Fact]
        public void ObterTaxaDeJuros_DeveRetornarStatusCode200()
        {
            // Arrange
            var controller = new TaxaJurosController();

            // Act
            var result = (OkObjectResult)controller.ObterTaxaDeJuros();

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public void ObterTaxaDeJuros_NaoDeveRetornarNulo()
        {
            // Arrange
            var controller = new TaxaJurosController();

            // Act
            var result = (OkObjectResult)controller.ObterTaxaDeJuros();

            // Assert
            result.StatusCode.Should().NotBeNull();
        }

        [Fact]
        public void ObterTaxaDeJuros_DeveRetornarValorFixo()
        {
            // Arrange
            var controller = new TaxaJurosController();

            // Act
            var result = (OkObjectResult)controller.ObterTaxaDeJuros();

            // Assert
            var expectedValue = 0.01;
            result.Value.Should().Be(expectedValue);
        }
    }
}
