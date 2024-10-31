using ExpectedObjects;

namespace DesafioPokerAplicandoTDD;

public class CartaTest
{
    [Theory]
    [InlineData("A", "O", 14)]
    [InlineData("10", "E", 10)]
    [InlineData("2", "P", 2)]
    public void DeveCriarUmaCarta(string valorDaCarta, string naipeDaCarta, int pesoDaCarta)
    {
        var cartaEsperada = new
        {
            Valor = valorDaCarta,
            Naipe = naipeDaCarta,
            Peso = pesoDaCarta
        };

        var carta = new Carta(cartaEsperada.Valor + cartaEsperada.Naipe);

        cartaEsperada.ToExpectedObject().ShouldMatch(carta);
    }

    [Theory]
    [InlineData("V", 11)]
    [InlineData("D", 12)]
    [InlineData("R", 13)]
    [InlineData("A", 14)]
    public void DeveCriarUmaCartaComPeso(string valorDaCarta, int pesoEsperado)
    {
        var carta = new Carta(valorDaCarta + "E");

        Assert.Equal(pesoEsperado, carta.Peso);
    }

    [Theory]
    [InlineData("-1")]
    [InlineData("0")]
    [InlineData("1")]
    [InlineData("15")]
    public void DeveValidarValorDaCarta(string valorDaCartaInvalido)
    {
        Assert.Throws<Exception>(() => new Carta(valorDaCartaInvalido + "O"));
    }

    [Theory]
    [InlineData("A")]
    [InlineData("Z")]
    public void DeveValidarNaipeDaCarta(string valorDoNaipeInvalido)
    {
        var mensagemDeErro =
            Assert.Throws<Exception>(() => new Carta("2" + valorDoNaipeInvalido)).Message;

        Assert.Equal("Naipe da carta inválido", mensagemDeErro);
    }
}
