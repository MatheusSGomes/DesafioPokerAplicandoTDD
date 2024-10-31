namespace DesafioPokerAplicandoTDD;

public class Carta
{
    public string Valor { get; internal set; }
    public int Peso { get; internal set; }

    public string Naipe { get; internal set; }

    public Carta(string carta)
    {
        Naipe = carta.Substring(carta.Length - 1); // Pega última posição da carta
        Valor = carta.Replace(Naipe, String.Empty); // Remove o Naipe


        if (Naipe != "O" && Naipe != "C" && Naipe != "E" && Naipe != "P")
            throw new Exception("Naipe da carta inválido");

        ConverterParaPeso(Valor);

        if (Peso < 2 || Peso > 14)
            throw new Exception("Valor da carta inválido");
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