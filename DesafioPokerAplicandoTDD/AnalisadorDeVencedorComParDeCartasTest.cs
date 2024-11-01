namespace DesafioPokerAplicandoTDD;

// Os testes dessa classe são apenas para quem tem par de cartas
public class AnalisadorDeVencedorComParDeCartasTest
{
    private readonly AnalisadorDeVencedorComParDeCartas _analisador;

    public AnalisadorDeVencedorComParDeCartasTest()
    {
        _analisador = new AnalisadorDeVencedorComParDeCartas();
    }

    [Theory]
    [InlineData("2O,2C,3P,6C,7C", "3O,5C,2E,9C,7P", "Primeiro Jogador")]
    [InlineData("3O,5C,2E,9C,7P", "2O,2C,3P,6C,7C", "Segundo Jogador")]
    [InlineData("2O,2C,3P,6C,7C", "DO,DC,2E,9C,7P", "Segundo Jogador")]
    [InlineData("DO,DC,2E,9C,7P", "2O,2C,3P,6C,7C", "Primeiro Jogador")]
    public void DeveAnalisarVencedorQuandoTiverUmParDeCartasDoMesmoValor(
        string cartasDoPrimeiroJogadorString,
        string cartasDoSegundoJogadorString,
        string vencedorEsperado)
    {
        var cartasDoPrimeiroJogador = cartasDoPrimeiroJogadorString.Split(",").ToList();
        var cartasDoSegundoJogador = cartasDoSegundoJogadorString.Split(",").ToList();

        var vencedor = _analisador.Analisar(cartasDoPrimeiroJogador, cartasDoSegundoJogador);

        Assert.Equal(vencedorEsperado, vencedor);
    }

    [Fact]
    public void NaoDeveAnalisarVencedorQuandoJogadoresNaoTemParDeCartas()
    {
        var cartasDoPrimeiroJogadorString = "2O,4C,3P,6C,7C";
        var cartasDoSegundoJogadorString = "3O,5C,2E,9C,7P";

        var cartasDoPrimeiroJogador = cartasDoPrimeiroJogadorString.Split(",").ToList();
        var cartasDoSegundoJogador = cartasDoSegundoJogadorString.Split(",").ToList();

        var vencedor = _analisador.Analisar(cartasDoPrimeiroJogador, cartasDoSegundoJogador);

        Assert.Null(vencedor);
    }
}

public class AnalisadorDeVencedorComParDeCartas
{
    public string Analisar(List<string> cartasDoPrimeiroJogador, List<string> cartasDoSegundoJogador)
    {
        var parDeCartasDoPrimeiroJogador = cartasDoPrimeiroJogador
            .Select(carta => new Carta(carta).Peso)
            .GroupBy(peso => peso)
            .Where(grupo => grupo.Count() > 1);

        var parDeCartasDoSegundoJogador = cartasDoSegundoJogador
            .Select(carta => new Carta(carta).Peso)
            .GroupBy(peso => peso)
            .Where(grupo => grupo.Count() > 1);

        if (parDeCartasDoPrimeiroJogador != null && parDeCartasDoPrimeiroJogador.Any() &&
            parDeCartasDoSegundoJogador != null && parDeCartasDoSegundoJogador.Any())
        {
            var maiorParDeCartasPrimeiroJogador = parDeCartasDoPrimeiroJogador
                .Select(valor => valor.Key).OrderBy(valor => valor).Max();

            var maiorParDeCartasSegundoJogador = parDeCartasDoSegundoJogador
                .Select(valor => valor.Key).OrderBy(valor => valor).Max();

            if (maiorParDeCartasPrimeiroJogador > maiorParDeCartasSegundoJogador)
                return "Primeiro Jogador";
            else if (maiorParDeCartasSegundoJogador > maiorParDeCartasPrimeiroJogador)
                return "Segundo Jogador";
        }

        else if (parDeCartasDoPrimeiroJogador != null && parDeCartasDoPrimeiroJogador.Any())
            return "Primeiro Jogador";

        else if (parDeCartasDoSegundoJogador != null && parDeCartasDoSegundoJogador.Any())
            return "Segundo Jogador";

        return null;
    }
}
