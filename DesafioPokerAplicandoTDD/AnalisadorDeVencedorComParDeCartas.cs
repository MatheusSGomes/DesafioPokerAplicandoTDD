namespace DesafioPokerAplicandoTDD;

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