using System;

namespace MyArray.Logic
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Arreglos? array = null;

                while (true)
                {
                    Console.WriteLine("\n======================= Menú =======================");
                    Console.WriteLine("1. Agregar un número");
                    Console.WriteLine("2. Insertar un número");
                    Console.WriteLine("3. Llenar matriz");
                    Console.WriteLine("4. Números primos");
                    Console.WriteLine("5. Números pares");
                    Console.WriteLine("6. Número no repetidos");
                    Console.WriteLine("7. Números más repetidos");
                    Console.WriteLine("8. Salir");
                    Console.Write("Seleccione una opción: ");
                    int option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Console.Write("Ingrese el tamaño de la matriz: ");
                            int matriztam = int.Parse(Console.ReadLine());
                            array = new Arreglos(matriztam);
                            break;
                        case 2:
                            if (array != null)
                            {
                                Console.Write("Ingrese el número a insertar: ");
                                int numToInsert = int.Parse(Console.ReadLine());
                            }
                            else
                            {
                                Console.WriteLine("Primero debe crear una matriz.");
                            }
                            break;
                        case 3:
                            if (array != null)
                            {
                                Console.Write("Llenar matriz: ");
                                int numtam = int.Parse(Console.ReadLine());
                                array.Fill(1, numtam);
                                array.Sort();
                                Console.WriteLine(array);
                            }
                            else
                            {
                                Console.WriteLine("Primero debe crear una matriz.");
                            }
                            break;
                        case 4:
                            if (array != null)
                            {
                                var getPrimo = array.Primos();
                                Console.WriteLine($"Los números primos son:\n{getPrimo}");
                            }
                            else
                            {
                                Console.WriteLine("Primero debe crear una matriz.");
                            }
                            break;
                        case 5:
                            if (array != null)
                            {
                                var getPares = array.Pares();
                                Console.WriteLine($"Los números pares son:\n{getPares}\n");
                            }
                            else
                            {
                                Console.WriteLine("Primero debe crear una matriz.");
                            }
                            break;
                        case 6:
                            if (array != null)
                            {
                                var nonRepeat = array.NotRepetidos();
                                nonRepeat.Sort();
                                Console.WriteLine($"Los números que no se repiten son:\n{nonRepeat}");
                            }
                            else
                            {
                                Console.WriteLine("Primero debe crear una matriz.");
                            }
                            break;
                        case 7:
                            if (array != null)
                            {
                                var newMoreRepit = array.MoreNumberRepit();
                                Console.WriteLine($"Los números que más se repiten son:\n{newMoreRepit}");
                            }
                            else
                            {
                                Console.WriteLine("Primero debe crear una matriz.");
                            }
                            break;
                        case 8:
                            Console.WriteLine("Saliendo del programa.");
                            return;
                        default:
                            Console.WriteLine("Opción inválida. Intente nuevamente.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}