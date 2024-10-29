using ExpectedObjects;

namespace DesafioPokerAplicandoTDD;

public class CartaTest
{
    [Fact]
    public void DeveCriarUmaCarta()
    {
        var cartaEsperada = new
        {
            Valor = 14,
            Naipe = "O"
        };

        var carta = new Carta(cartaEsperada.Valor, cartaEsperada.Naipe);

        cartaEsperada.ToExpectedObject().ShouldMatch(carta);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(15)]
    public void DeveValidarValorDaCarta(int valorDaCartaInvalido)
    {
        Assert.Throws<Exception>(() => new Carta(valor: valorDaCartaInvalido, naipe: "O"));
    }
}

public class Carta
{
    public int Valor { get; set; }

    public string Naipe { get; set; }

    public Carta(int valor, string naipe)
    {
        if (valor < 2 || valor > 14)
            throw new Exception("Valor da carta inválido");

        Valor = valor;
        Naipe = naipe;
    }
}
