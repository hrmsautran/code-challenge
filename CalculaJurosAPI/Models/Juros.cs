namespace CalculaJurosAPI.Models
{
    public class Juros
    {
        public Juros(decimal valorInicial, int meses, double taxaDeJuros)
        {
            ValorInicial = valorInicial;
            Meses = meses;
            TaxaDeJuros = taxaDeJuros;
        }

        public decimal ValorInicial { get; set; }
        public int Meses { get; set; }
        public double TaxaDeJuros { get; set; }

        public decimal Calcular()
        {
            var resutl = this.ValorInicial * (decimal)Math.Pow(1 + this.TaxaDeJuros, this.Meses);

            return Math.Floor(resutl * 100) / 100M;
        }
    }
}
