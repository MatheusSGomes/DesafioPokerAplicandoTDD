using ExpectedObjects;

namespace DesafioPokerAplicandoTDD;

public class CartaTest
{
    [Fact]
    public void DeveCriarUmaCarta()
    {
        var cartaEsperada = new
        {
            Valor = "A",
            Naipe = "O"
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
