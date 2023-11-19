// See https://aka.ms/new-console-template for more information
//requizitos 1.Cuando se acabe la partida se borre la terminal, que se indique cuantas monedas uno quiere apostar, cuando se gane al diler se recupere las monedas apostadas

System.Random random = new System.Random();

int totalJugador = 0;
int totalRepartidor = 0;
string message = "";
Console.WriteLine("Escriba la condicion");
string switchControl = "menu";
string continuePlay = "continuar";
int carta;
string validateCard = "";
int coinCasino = 0;
int monedasApostadas = 0;

while (continuePlay != "cerrar")
{
    Console.Clear();

    switchControl = "menu";
    monedasApostadas = 0;

    Console.WriteLine("Bienvenido al casino\n");
    Console.WriteLine("Para jugar necesitas monedas por favor indica cuantas monedas necestias\n");
    coinCasino = Convert.ToInt32(Console.ReadLine());

    while (coinCasino > 0)
    {
        totalJugador = 0;
        totalJugador = 0;

        switch (switchControl)
        {
            case "menu":
                Console.WriteLine("Escriba '21' para empezar a jugar 21 \n");
                switchControl = Console.ReadLine();
                break;

            case "21":
                Console.WriteLine("Indique cuantas monedas quieres apostar");
                monedasApostadas = Convert.ToInt32(Console.ReadLine());
                if (monedasApostadas <= coinCasino)
                {
                    coinCasino = coinCasino - monedasApostadas;
                    do
                    {
                        Console.WriteLine("Toma la carta jugador");
                        carta = random.Next(1, 12);
                        totalJugador = totalJugador + carta;
                        Console.WriteLine($"La cara que te salio es {carta}, tu total es de {totalJugador}\n");
                        Console.WriteLine($"Desea coger otra carta");
                        validateCard = Console.ReadLine();
                    } while (validateCard == "Si" || validateCard == "yes" || validateCard == "si");

                    totalRepartidor = random.Next(12, 21);

                    Console.WriteLine($"\nEl total del repartidor es {totalRepartidor}\n");

                    if (totalJugador > totalRepartidor && totalJugador <= 21)
                    {
                        message = "Felicidades ganaste\n";
                        coinCasino = coinCasino + (monedasApostadas * 2);
                    }
                    else if (totalJugador > 21)
                    {
                        message = "Perdiste el numero no puede ser mayor que 21\n";
                    }
                    else if (totalJugador <= totalRepartidor)
                    {
                        message = "Perdiste el numero es menor o igual al del repartidor\n";
                    }
                    else
                    {
                        message = "Condicion no valida\n";
                    }

                    Console.WriteLine(message);
                    Console.WriteLine($"la monedas que te quedan son {coinCasino}\n");
                }
                else
                {
                    Console.WriteLine("No puede apostar mas monedas de las que tiene\n");
                }

                break;

            default:
                Console.WriteLine("Este caso no existe\n");
                continuePlay = "cerrar";
                break;
        }
    }
    Console.WriteLine("Se acabaron tus monedas \n");
    Console.WriteLine("Escriba 'cerrar' para terminar de jugar o 'continuar' para seguir");
    continuePlay = Console.ReadLine();
}






