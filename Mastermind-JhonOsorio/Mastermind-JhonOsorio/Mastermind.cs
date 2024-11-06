using System;
using UtilsLibrary;

// Creamos la base del programa
namespace Mastermind_JhonOsorio
{
    public class MastermindJhon
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool continuePlaying = true;
            while (continuePlaying)
            {
                // Creamos la array con el codigo secreto, con los numeros del usuario, y la pista final.
                int[] numSecreto = new int [4];
                int[] numUser = new int[4];
                string[] pista = new string[4];

                int opcionSeleccionada;
                int intentos;

                Console.Clear();
                opcionSeleccionada = MenuOpcionesUI();

                if (opcionSeleccionada == 1)
                {
                    Utils.GetNumbers(numSecreto);
                    Utils.ReadArray(numSecreto);
                }
                //Devuelve de manera aleatoria el numero secreto 
                else if (opcionSeleccionada == 2)
                {
                    Utils.GetNumbersRandoms(numSecreto);
                }
                else if (opcionSeleccionada == 3) 
                {
                    break;//LAMENTO ESTE BREAK T-T
                }
               
                //MENU DEL JUEGO
                intentos = MenuJuegoUI();
               
                //Introducimos el numero que guardara el nSecreto
                Intentos(intentos, numUser, numSecreto, pista);

                // Preguntar si el usuario quiere volver a jugar
                Console.WriteLine("\n¿Quieres volver a jugar? (s/n)");
                string respuesta = Console.ReadLine();
                if (respuesta.ToLower() != "s")
                {
                    continuePlaying = false;
                }
                
            }
            Console.WriteLine("Gracias por jugar. ¡Hasta la próxima!");

        }
        //Cuerpo del juego donde se implementan la cantidad de intentos 
        public static void Intentos(int intentos, int[] numUser, int[] numSecreto, string[] pista)
        {
            int exit = 0;
            for (int i = 1; i <= intentos && exit == 0; i++)
            {
                //Introducimos el numero del usuario
                Console.WriteLine("\n\n🌀 INGRESA TUS NUMEROS USUARIO");
                Utils.GetNumbers(numUser);
                Utils.ReadArray(numUser);

                // Comparar los arrays numSecreto y numUser y guarda la posicion de las pistas
                Utils.CompareArray(numSecreto, numUser, pista);

                Console.Write("\n\n🧩 Pista:");
                //Nos devuelve la array pista   
                Utils.ReadArray(pista);

                if (Utils.CompareArrayEquals(numUser, numSecreto))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n🎉 FELICIDADES HAS ANCERTADO EL NUMERO🎉");
                    exit = 1;
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"\nTe quedan {intentos - i} intentos.");
                }

            }
            if (exit == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"💔  HAS PERDIDO");
                Utils.ReadArray(numSecreto);
                Console.ResetColor();
            }
            else Console.WriteLine("Saliendo");
        }
        
            public static int MenuJuegoUI()
            {
                // Cambiar el color del texto
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("\n*********** MASTERMIND BY JHON ***********");
                Console.Write("*  ");
                Console.Write("¡Bienvenido al juego Mastermind!      ");
                Console.Write("*\n");
                Console.Write("*   ");
                Console.Write("Seleccione su dificultad:            ");
                Console.Write("*\n");
                Console.WriteLine("******************************************\n");

                Console.ForegroundColor = ConsoleColor.White; // Restablecer el color a blanco para las opciones


                Console.WriteLine("1. Dificultad Novato    (10 intentos)");
                Console.WriteLine("2. Dificultad Aficionado (6 intentos)");
                Console.WriteLine("3. Dificultad Experimentado (4 intentos)");
                Console.WriteLine("4. Dificultad Maestro    (2 intentos)");
                Console.WriteLine("5. Dificultad Personalizada");
                Console.WriteLine("\n===========================================");
                Console.ResetColor();

                try
                {
                    Console.WriteLine("\nElige una dificultad: ");
                    int numUser;
                    int numOpcion;
                    numOpcion = int.Parse(Console.ReadLine());

                    switch (numOpcion)
                    {
                        case 1:
                            numOpcion = 10;
                            Console.WriteLine("\nHas elegido novato");
                            break;

                        case 2:
                            numOpcion = 6;
                            Console.WriteLine("\nHas elegido aficionado");
                            break;

                        case 3:
                            numOpcion = 4;
                            Console.WriteLine("\nHas elegido experimentado");
                            break;

                        case 4:
                            numOpcion = 2;
                            Console.WriteLine("\nHas elegido maestro");
                            break;

                        case 5:
                            Console.WriteLine("\nHas elegido personalizado");
                            Console.WriteLine("\n¿Cuántos intentos quieres?");
                            numUser = int.Parse(Console.ReadLine());
                            return numUser;

                        default:
                            Console.WriteLine("Opción no válida. Por favor, elige una opción del 1 al 5.");
                            // Llamada recursiva si la opción no es válida
                            return MenuJuegoUI();
                    }
                    return numOpcion;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada no válida. Por favor, introduce un número entre 1 y 5.");
                    // Llamada recursiva si el formato es incorrecto
                    return MenuJuegoUI();
                }
            }
            public static int MenuOpcionesUI()
            {
                Console.WriteLine("1. MasterMind + Joc de proves ");
                Console.WriteLine("2. Mastermind ");
                Console.WriteLine("3. Salir ");

                while (true) // Bucle para volver a pedir la opción si no es válida
                {
                    try
                    {
                        Console.WriteLine("\nElige qué quieres hacer: ");
                        int numOpcion = int.Parse(Console.ReadLine());

                        switch (numOpcion)
                        {
                            case 1:
                                Console.WriteLine("\nHas elegido MasterMind + Joc de proves");
                                return numOpcion;

                            case 2:
                                Console.WriteLine("\nHas elegido MasterMind");
                                return numOpcion;

                            case 3:
                                Console.WriteLine("\nHas elegido salir");
                                return numOpcion;

                            default:
                                Console.WriteLine("Opción no válida. Por favor, elige una opción del 1 al 3.");
                                break; // Permite volver al comienzo del bucle en lugar de una recursión
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("No ingreses letras. Por favor, introduce un número entre 1 y 3.");
                        // Continúa el bucle y vuelve a pedir la opción sin necesidad de recursión
                    }
                }
            }
    } 
}