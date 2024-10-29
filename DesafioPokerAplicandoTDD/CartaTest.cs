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
}

public class Carta
{
    public int Valor { get; set; }

    public string Naipe { get; set; }

    public Carta(int valor, string naipe)
    {
        Valor = valor;
        Naipe = naipe;
    }
}
