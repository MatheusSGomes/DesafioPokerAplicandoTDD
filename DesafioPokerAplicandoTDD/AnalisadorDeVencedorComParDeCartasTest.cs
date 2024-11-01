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
