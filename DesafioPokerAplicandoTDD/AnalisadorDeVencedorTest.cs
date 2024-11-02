using Moq;

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
    private readonly Mock<IAnalisadorDeVencedorComMaiorCarta> _analisadorDeVencedorComMaiorCarta;
    private readonly AnalisadorDeVencedor _analisador;
    private readonly Mock<IAnalisadorDeVencedorComParDeCartas> _analisadorDeVencedorComParDeCartas;

    public AnalisadorDeVencedorTest()
    {
        _analisadorDeVencedorComMaiorCarta = new Mock<IAnalisadorDeVencedorComMaiorCarta>();
        _analisadorDeVencedorComParDeCartas = new Mock<IAnalisadorDeVencedorComParDeCartas>();
        _analisador = new AnalisadorDeVencedor(
            _analisadorDeVencedorComMaiorCarta.Object,
            _analisadorDeVencedorComParDeCartas.Object);
    }

    [Fact]
    public void DeveAnalisarVencedorQueTemMaiorCarta()
    {}
}
