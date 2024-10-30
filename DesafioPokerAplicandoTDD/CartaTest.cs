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

        var carta = new Carta(cartaEsperada.Valor, cartaEsperada.Naipe);

        cartaEsperada.ToExpectedObject().ShouldMatch(carta);
    }

    [Theory]
    [InlineData("V", 11)]
    [InlineData("D", 12)]
    [InlineData("R", 13)]
    [InlineData("A", 14)]
    public void DeveCriarUmaCartaComPeso(string valorDaCarta, int pesoEsperado)
    {
        var carta = new Carta(valor: valorDaCarta, naipe: "E");

        Assert.Equal(pesoEsperado, carta.Peso);
    }

    [Theory]
    [InlineData("-1")]
    [InlineData("0")]
    [InlineData("1")]
    [InlineData("15")]
    public void DeveValidarValorDaCarta(string valorDaCartaInvalido)
    {
        Assert.Throws<Exception>(() => new Carta(valor: valorDaCartaInvalido, naipe: "O"));
    }

    [Theory]
    [InlineData("A")]
    [InlineData("Z")]
    public void DeveValidarNaipeDaCarta(string valorDoNaipeInvalido)
    {
        var mensagemDeErro =
            Assert.Throws<Exception>(() => new Carta(valor: "2", naipe: valorDoNaipeInvalido)).Message;

        Assert.Equal("Naipe da carta inválido", mensagemDeErro);
    }
}

public class Carta
{
    public string Valor { get; set; }
    public int Peso { get; set; }

    public string Naipe { get; set; }

    public Carta(string valor, string naipe)
    {
        // if (Peso < 2 || Peso > 14)
        //     throw new Exception("Valor da carta inválido");

        if (naipe != "O" && naipe != "C" && naipe != "E" && naipe != "P")
            throw new Exception("Naipe da carta inválido");

        Valor = valor;
        Naipe = naipe;
        ConverterParaPeso(valor);
    }

    private void ConverterParaPeso(string valorDaCarta)
    {
        if (!int.TryParse(valorDaCarta, out var valorOutput))
        {
            switch (valorDaCarta)
            {
                case "V":
                    valorOutput = 11;
                    break;
                case "D":
                    valorOutput = 12;
                    break;
                case "R":
                    valorOutput = 13;
                    break;
                case "A":
                    valorOutput = 14;
                    break;
                default:
                    valorOutput = 0;
                    break;
            }
        }

        Peso = valorOutput;
    }
}
