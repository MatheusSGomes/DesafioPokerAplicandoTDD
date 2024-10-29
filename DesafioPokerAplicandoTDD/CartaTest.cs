namespace DesafioPokerAplicandoTDD;

public class CartaTest
{
    [Fact]
    public void DeveCriarUmaCarta()
    {
        const int valorEsperado = 14;
        const string naipeEsperado = "O";

        var carta = new Carta(valorEsperado, naipeEsperado);

        Assert.Equal(valorEsperado, carta.Valor);
        Assert.Equal(naipeEsperado, carta.Naipe);
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
