using Xunit;
using FluentAssertions;
using CalculaJurosAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Unit.CalculaJurosAPI.Controllers
{
    public class ShowMeTheCodeControllerTest
    {
        [Fact]
        public void ShowMeTheCode_DeveRetornarURLdoRepositorioDoProjeto()
        {
            // Arrange
            var controller = new ShowMeTheCodeController();

            // Act
            var result = (OkObjectResult)controller.Get();

            // Assert
            var githubRepo = "https://github.com/hrmsautran/code-challenge";

            result.Value.Should().Be(githubRepo);
        }
    }
}
