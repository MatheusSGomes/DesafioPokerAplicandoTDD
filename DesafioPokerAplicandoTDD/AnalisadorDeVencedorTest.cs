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
    private readonly AnalisadorDeVencedor _analisador;

    public AnalisadorDeVencedorTest()
    {
        _analisador = new AnalisadorDeVencedor();
    }

    [Theory]
    [InlineData("2O,4C,3P,6C,7C", "3O,5C,2E,9C,7P", "Segundo Jogador")]
    [InlineData( "3O,5C,2E,9C,7P", "2O,4C,3P,6C,7C", "Primeiro Jogador")]
    [InlineData( "3O,5C,2E,9C,7P", "2O,4C,3P,6C,10E", "Segundo Jogador")]
    [InlineData( "3O,5C,2E,9C,VP", "2O,4C,3P,6C,AE", "Segundo Jogador")]
    public void DeveAnalisarVencedorQuandoTiverMaiorCarta(
        string cartasDoPrimeiroJogadorString,
        string cartasDoSegundoJogadorString,
        string vencedorEsperado)
    {
        var cartasDoPrimeiroJogador = cartasDoPrimeiroJogadorString.Split(",").ToList();
        var cartasDoSegundoJogador = cartasDoSegundoJogadorString.Split(",").ToList();

        var vencedor = _analisador.Analisar(cartasDoPrimeiroJogador, cartasDoSegundoJogador);

        Assert.Equal(vencedorEsperado, vencedor);
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

    [Theory]
    [InlineData("3O,5C,RE,AC,RP", "RO,4C,3P,RC,7C", "Primeiro Jogador")]
    [InlineData("RO,4C,3P,RC,7C", "3O,5C,RE,AC,RP", "Segundo Jogador")]
    public void DeveAnalisarVencedorQuandoDoisJogadoresEstaoEmpatadosEmParEhVencedorOQueTemAMaiorCarta(
        string cartasDoPrimeiroJogadorString,
        string cartasDoSegundoJogadorString,
        string vencedorEsperado)
    {
        var cartasDoPrimeiroJogador = cartasDoPrimeiroJogadorString.Split(",").ToList();
        var cartasDoSegundoJogador = cartasDoSegundoJogadorString.Split(",").ToList();
        var vencedor = _analisador.Analisar(cartasDoPrimeiroJogador, cartasDoSegundoJogador);

        Assert.Equal(vencedorEsperado, vencedor);
    }
}

public class AnalisadorDeVencedor
{
    public string Analisar(List<string> cartasDoPrimeiroJogador, List<string> cartasDoSegundoJogador)
    {
        var parDeCartasDoPrimeiroJogador = cartasDoPrimeiroJogador
            .Select(carta => ConverterParaValorDaCarta(carta))
            .GroupBy(valorDaCarta => valorDaCarta)
            .Where(grupo => grupo.Count() > 1);

        var parDeCartasDoSegundoJogador = cartasDoSegundoJogador
            .Select(carta => ConverterParaValorDaCarta(carta))
            .GroupBy(valorDaCarta => valorDaCarta)
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

        var maiorCartaDoPrimeiroJogador = cartasDoPrimeiroJogador
            .Select(carta => ConverterParaValorDaCarta(carta))
            .OrderBy(valorDaCarta => valorDaCarta)
            .Max();

        var maiorCartaDoSegundoJogador = cartasDoSegundoJogador
            .Select(carta => ConverterParaValorDaCarta(carta))
            .OrderBy(valorDaCarta => valorDaCarta)
            .Max();

        return (maiorCartaDoPrimeiroJogador > maiorCartaDoSegundoJogador)
            ? "Primeiro Jogador"
            : "Segundo Jogador";
    }

    // OBS: Métodos private não são testados diretamente (são testados indiretamente pelos métodos public)
    private int ConverterParaValorDaCarta(string carta)
    {
        var valorDaCarta = carta.Substring(0, carta.Length - 1);

        if (!int.TryParse(valorDaCarta, out var valor))
        {
            switch (valorDaCarta)
            {
                case "V":
                    valor = 11;
                    break;
                case "D":
                    valor = 12;
                    break;
                case "R":
                    valor = 13;
                    break;
                case "A":
                    valor = 14;
                    break;
                default:
                    valor = 0;
                    break;
            }
        }

        return valor;
    }
}
