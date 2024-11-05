using System;

// Creamos la base del programa
namespace Mastermind
{
    public class Mastermind
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool continuePlaying = true;
            while (continuePlaying)
            {
                // Creamos la array con el codigo secreto, con los numeros del usuario, y la pista final.
                int[] numSecreto = new int [4];
                int[] numUser = new int[4];
                string[] pista = new string[4];

                int intentos;

                Console.Clear();
                
                if (MenuOpciones() == 1)
                {
                    GetNumbers(numSecreto);
                }
                //Devuelve de manera aleatoria el numero secreto 
                else GetNumbersRandoms(numSecreto);



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
    
        public static void MenuOpcionesUI()
        {
            Console.WriteLine("1. MasterMind + Joc de proves ");
            Console.WriteLine("2. Mastermind ");
            
        }
        public static int MenuOpciones()
        {
            try
            {
                Console.WriteLine("\nElige que quieres hacer: ");
                int numUser;
                int numOpcion;
                numOpcion = int.Parse(Console.ReadLine());

                switch (numOpcion)
                {
                    case 1:
                        Console.WriteLine("\nHas elegido MasterMind + Joc de proves");
                        break;

                    case 2:
                        Console.WriteLine("\nHas elegido MasterMind");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Por favor, elige una opción del 1 al 5.");
                        // Llamada recursiva si la opción no es válida
                        return MenuOpcionesUI();
                }
                return numOpcion;
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada no válida. Por favor, introduce un número entre 1 y 5.");
                // Llamada recursiva si el formato es incorrecto
                return MenuOpcionesUI();
            }
        }

        //Cuerpo del juego donde se implementan la cantidad de intentos 
        public static void Intentos(int intentos, int[] numUser, int[] numSecreto, string[] pista)
        {
            int exit = 0;
            for (int i = 1; i <= intentos && exit == 0; i++)
            {
                //Introducimos el numero del usuario
                Console.WriteLine("\n\n🌀 INGRESA TUS NUMEROS USUARIO");
                GetNumbers(numUser);
                ReadArray(numUser);

                // Comparar los arrays numSecreto y numUser y guarda la posicion de las pistas
                CompareArray(numSecreto, numUser, pista);

                Console.Write("\n\n🧩 Pista:");
                //Nos devuelve la array pista   
                ReadArray(pista);

                if (CompareArrayEquals(numUser, numSecreto))
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
                ReadArray(numSecreto);
                Console.ResetColor();
            }
            else Console.WriteLine("Saliendo");
        }

        //Funcion para rellenar automaticamente una array
        public static void GetNumbers(int[] num) 
        {
            for (int i = 0; i < num.Length; i++)
            {
                // Variable para almacenar temporalmente el número introducido por el usuario
                Console.Write($"Ingrese el {i + 1} número (entre 1 y 6): ");

                try
                {
                    int numero = int.Parse(Console.ReadLine());

                    // Verificar si el número está dentro del rango permitido
                    if (numero < 1 || numero > 6)
                    {
                        Console.WriteLine("Número fuera del rango. Debe estar entre 1 y 6.");
                        i--; // Decrementar 'i' para repetir la entrada actual
                    }
                    else
                    {
                        // Guardamos el número en el array
                        num[i] = numero;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.");
                    i--; // Decrementar 'i' para repetir la entrada actual en caso de error de formato
                }
            }

        }

        // Rellena de manera aleatoria una array
        private static void GetNumbersRandoms(int[] num)
        {
            Random rand = new();

            for (int i = 0; i < num.Length; i++)
            {
                // Variable para almacenar temporalmente el número introducido por el usuario
                num[i] = rand.Next(1,6);
            }
        }

        //Funciones para leer un array int y string
        public static void ReadArray(int[] num)
        {
            Console.WriteLine("\nEL NUMERO DADO ES:");
            for (int i = 0; i < num.Length; i++)
            {
                Console.Write($"{num[i]} ");
            }
        }
        public static void ReadArray(string[] num)
        {
            for (int i = 0; i < num.Length; i++)
            {
                Console.Write($"{num[i]} ");
            }
        }

        // Funcion para comparar Arrays
        public static void CompareArray(int[] numSecret, int[] numUser, string[] pista)
        {
            for (int i = 0; i < numSecret.Length; i++)
            {
                if (numUser[i] == numSecret[i])
                {
                    // Coincide en valor y posición
                    pista[i] = "O"; 
                }
                else
                {
                    // Comprobar si el número está en el número secreto pero en otra posición y lo usamos de break
                    int encontradoEnOtraPosicion = 0;
                    for (int j = 0; j < numSecret.Length && encontradoEnOtraPosicion == 0; j++)
                    {
                        if (numUser[i] == numSecret[j] && i != j)
                        {
                            //Marca que se encontró el valor en otra posición y hace el break al cambiar el valor a 1
                            encontradoEnOtraPosicion = 1;
                        }
                    }
                    // Trinario para  marcar "Ø" si está en otra posición, "×" si no coincide
                    pista[i] = encontradoEnOtraPosicion == 1 ? "Ø" : "×";
                }
            }
        }

        // Comprobar si 2 arrays son iguales tanto en posicion como valor
        public static bool CompareArrayEquals(int[] pista, int[] pistaCorrecta)
        {

            for (int i = 0; i < pista.Length; i++)
            {
                // Si algún elemento no coincide, no son iguales
                if (pista[i] != pistaCorrecta[i]) return false; 
            }
            // Si todos los elementos coinciden, son iguales
            return true; 
        }
    } 
}