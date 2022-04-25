using Xunit;
using FluentAssertions;
using CalculaJurosAPI.Models;

namespace Tests.Unit.TaxaDeJurosAPI.Models
{
    public class JurosTest
    {
        [Theory]
        [InlineData(100, 5, 0.01, 105.10)]
        [InlineData(90, 8, 0.01, 97.45)]
        [InlineData(100.40, 3, 0.01, 103.44)]
        public void JurosModel_DeveRetornarValorCalculado(decimal valorInicial, int meses, double taxaJuros, decimal expected)
        {
            var jurosModel = new Juros(valorInicial, meses, taxaJuros);

            var result = jurosModel.Calcular();
            result.Should().Be(expected);
        }
    }
}
