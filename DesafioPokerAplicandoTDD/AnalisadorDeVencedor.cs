namespace DesafioPokerAplicandoTDD;

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