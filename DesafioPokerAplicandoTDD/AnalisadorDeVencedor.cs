using Moq;

namespace DesafioPokerAplicandoTDD;

// Essa classe se tornou uma controler, porque o objetivo dela agora é controlar as outras classes de serviço
public class AnalisadorDeVencedor
{
    private readonly IAnalisadorDeVencedorComMaiorCarta _analisadorDeVencedorComMaiorCarta;
    private readonly IAnalisadorDeVencedorComParDeCartas _analisadorDeVencedorComParDeCartas;

    public AnalisadorDeVencedor(
        IAnalisadorDeVencedorComMaiorCarta analisadorDeVencedorComMaiorCarta,
        IAnalisadorDeVencedorComParDeCartas analisadorDeVencedorComParDeCartas)
    {
        _analisadorDeVencedorComMaiorCarta = analisadorDeVencedorComMaiorCarta;
        _analisadorDeVencedorComParDeCartas = analisadorDeVencedorComParDeCartas;
    }

    public string Analisar(List<string> cartasDoPrimeiroJogador, List<string> cartasDoSegundoJogador)
    {
        var vencedor = _analisadorDeVencedorComMaiorCarta.Analisar(cartasDoPrimeiroJogador, cartasDoSegundoJogador);
        vencedor = _analisadorDeVencedorComParDeCartas.Analisar(cartasDoPrimeiroJogador, cartasDoSegundoJogador);

        return vencedor;
    }
}
