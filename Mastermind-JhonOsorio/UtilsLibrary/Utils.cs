namespace UtilsLibrary
{
    public class Utils
    {
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
            public static void GetNumbersRandoms(int[] num)
            {
                Random rand = new();

                for (int i = 0; i < num.Length; i++)
                {
                    // Variable para almacenar temporalmente el número introducido por el usuario
                    num[i] = rand.Next(1, 6);
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
