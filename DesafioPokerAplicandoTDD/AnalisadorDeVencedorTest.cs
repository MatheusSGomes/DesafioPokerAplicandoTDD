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
    private readonly string _cartasDoPrimeiroJogadorString;
    private readonly string _cartasDoSegundoJogadorString;
    private readonly List<string> _cartasDoPrimeiroJogador;
    private readonly List<string> _cartasDoSegundoJogador;

    public AnalisadorDeVencedorTest()
    {
        _analisadorDeVencedorComMaiorCarta = new Mock<IAnalisadorDeVencedorComMaiorCarta>();
        _analisadorDeVencedorComParDeCartas = new Mock<IAnalisadorDeVencedorComParDeCartas>();

        _analisador = new AnalisadorDeVencedor(
            _analisadorDeVencedorComMaiorCarta.Object,
            _analisadorDeVencedorComParDeCartas.Object);
        
        _cartasDoPrimeiroJogadorString = "2O,4C,3P,6C,7C";
        _cartasDoSegundoJogadorString = "3O,5C,2E,9C,7P";
        
        _cartasDoPrimeiroJogador = _cartasDoPrimeiroJogadorString.Split(",").ToList();
        _cartasDoSegundoJogador = _cartasDoSegundoJogadorString.Split(",").ToList();
    }

    [Fact]
    public void DeveAnalisarVencedorQueTemMaiorCarta()
    {
        /*
         * O objetivo do teste na controller não é saber se o retorno está correto
         * e sim se o método Analisar foi chamado.
         * Não só se foi chamado, mas se foi chamado com os parâmetros corretos.
         */

        

        // Configurar comportamento do método Analisar (mock)
        // Ou seja, ao chamar o analisar com 2 parâmetros, será retornada uma string.
        _analisadorDeVencedorComMaiorCarta
            .Setup(analisador => analisador.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador))
            .Returns("Segundo Jogador");

        _analisador.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador);

        // Valido se o Analisar (mock) foi chamado.
        _analisadorDeVencedorComMaiorCarta.Verify(
            analisador => analisador.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador));
    }

    [Fact]
    public void DeveAnalisarVencedorQueTemParDeCartas()
    {
        // Fazer mock (atribuir um comportamento)
        _analisadorDeVencedorComParDeCartas
            .Setup(analisador => analisador.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador))
            .Returns("Segundo Jogador");

        _analisador.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador);

        // Verifico se foi chamado
        _analisadorDeVencedorComParDeCartas.Verify(
            analisador => analisador.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador));
    }

    [Fact]
    public void NaoDeveAnalisarVencedorComMaiorCartaQuandoJogadaTerCartasComPar()
    {
        // Fazer mock (atribuir um comportamento)
        _analisadorDeVencedorComParDeCartas
            .Setup(analisador => analisador.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador))
            .Returns("Segundo Jogador");

        _analisador.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador);

        // Verifico se foi NUNCA foi chamado
        _analisadorDeVencedorComMaiorCarta.Verify(
            analisador => analisador.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador), Times.Never);
    }
}
