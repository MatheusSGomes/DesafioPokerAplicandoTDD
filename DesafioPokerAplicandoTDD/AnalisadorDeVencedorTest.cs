namespace DesafioPokerAplicandoTDD;

/*
 *
 * História do usuário:
 * No jogo de Poker, uma mão consiste em 5 cartas que podem ser comparadas da mais baixa para a mais alta da seguinte maneira:
 * - Carta alta: é a carta de maior valor.
 * - Um par: são 2 cartas do mesmo valor.
 * - Flush: Todas as cartas do mesmo naipe.
 *
 * As cartas devem ser validadas.
 * As cartas são, em ordem crescente de valor: 2, 3, 4, 5, 6, 7, 8, 9, 10, Valete, Dama, Rei e Ás.
 * Os naipes são: Ouro (D), Copa (H), Espada (S), Paus (C).
 *
 */
public class AnalisadorDeVencedorTest
{
    [Theory]
    [InlineData("2O,4C,3P,6C,7C", "3O,5C,2E,9C,7P", "Segundo Jogador")]
    [InlineData( "3O,5C,2E,9C,7P", "2O,4C,3P,6C,7C", "Primeiro Jogador")]
    [InlineData( "3O,5C,2E,9C,7P", "2O,4C,3P,6C,10E", "Segundo Jogador")]
    public void DeveAnalisarVencedorQuandoTiverMaiorCarta(
        string cartasDoPrimeiroJogadorString,
        string cartasDoSegundoJogadorString,
        string vencedorEsperado)
    {
        var analisador = new AnalisadorDeVencedor();

        var cartasDoPrimeiroJogador = cartasDoPrimeiroJogadorString.Split(",").ToList();
        var cartasDoSegundoJogador = cartasDoSegundoJogadorString.Split(",").ToList();

        var vencedor = analisador.Analisar(cartasDoPrimeiroJogador, cartasDoSegundoJogador);

        Assert.Equal(vencedorEsperado, vencedor);
    }
}

public class AnalisadorDeVencedor
{
    public string Analisar(List<string> cartasDoPrimeiroJogador, List<string> cartasDoSegundoJogador)
    {
        var maiorCartaDoPrimeiroJogador = cartasDoPrimeiroJogador
            .Select(carta => int.Parse(carta.Substring(0, carta.Length - 1)))
            .OrderBy(valorDaCarta => valorDaCarta)
            .Max();

        var maiorCartaDoSegundoJogador = cartasDoSegundoJogador
            .Select(carta => int.Parse(carta.Substring(0, carta.Length - 1)))
            .OrderBy(valorDaCarta => valorDaCarta)
            .Max();

        return (maiorCartaDoPrimeiroJogador > maiorCartaDoSegundoJogador)
            ? "Primeiro Jogador"
            : "Segundo Jogador";
    }
}
