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

    [Theory]
    [InlineData("A")]
    [InlineData("Z")]
    public void DeveValidarNaipeDaCarta(string valorDoNaipeInvalido)
    {
        Assert.Throws<Exception>(() => new Carta(valor: 2, naipe: valorDoNaipeInvalido));
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

        if (naipe != "O" && naipe != "C" && naipe != "E" && naipe != "P")
            throw new Exception("Naipe da carta inválido");

        Valor = valor;
        Naipe = naipe;
    }
}
