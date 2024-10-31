namespace DesafioPokerAplicandoTDD;

public class AnalisadorDeVencedorComMaiorCartaTest
{
    [Theory]
    [InlineData("2O,4C,3P,6C,7C", "3O,5C,2E,9C,7P", "Segundo Jogador")]
    [InlineData("3O,5C,2E,9C,7P", "2O,4C,3P,6C,7C", "Primeiro Jogador")]
    [InlineData("3O,5C,2E,9C,7P", "2O,4C,3P,6C,10E", "Segundo Jogador")]
    [InlineData("3O,5C,2E,9C,VP", "2O,4C,3P,6C,AE", "Segundo Jogador")]
    public void DeveAnalisarVencedorQuandoTiverMaiorCarta(
        string cartasDoPrimeiroJogadorString,
        string cartasDoSegundoJogadorString,
        string vencedorEsperado)
    {
        var cartasDoPrimeiroJogador = cartasDoPrimeiroJogadorString.Split(",").ToList();
        var cartasDoSegundoJogador = cartasDoSegundoJogadorString.Split(",").ToList();

        var analisador = new AnalisadorDeVencedorComMaiorCarta();

        var vencedor = analisador.Analisar(cartasDoPrimeiroJogador, cartasDoSegundoJogador);

        Assert.Equal(vencedorEsperado, vencedor);
    }
}

public class AnalisadorDeVencedorComMaiorCarta
{
    public string Analisar(List<string> cartasDoPrimeiroJogador, List<string> cartasDoSegundoJogador)
    {
        var cartaComMaiorPesoDoPrimeiroJogador = cartasDoPrimeiroJogador
            .Select(carta => new Carta(carta).Peso)
            .OrderBy(peso => peso)
            .Max();

        var cartaComMaiorPesoDoSegundoJogador = cartasDoSegundoJogador
            .Select(carta => new Carta(carta).Peso)
            .OrderBy(peso => peso)
            .Max();

        return (cartaComMaiorPesoDoPrimeiroJogador > cartaComMaiorPesoDoSegundoJogador)
            ? "Primeiro Jogador"
            : "Segundo Jogador";
    }
}
