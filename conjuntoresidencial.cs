using System;

namespace SistemaResidencial
{
    class Program
    {
        static void Main(string[] args)
        {
            // Capacidad máxima de 40 ingresos diarios
            int MAX_INGRESOS = 40;

            // Arreglos para almacenar los datos
            string[] placas = new string[MAX_INGRESOS];
            string[] torres = new string[MAX_INGRESOS];
            string[] apartamentos = new string[MAX_INGRESOS];
            double[] horasIngreso = new double[MAX_INGRESOS];
            double[] tiemposPermanencia = new double[MAX_INGRESOS];
            string[] tiposVehiculo = new string[MAX_INGRESOS];

            int totalIngresos = 0;
            int opcion = 0;

            do
            {
                Console.WriteLine("\n=== SISTEMA DE CONTROL DE PARQUEADERO ===");
                Console.WriteLine("1. Registrar ingreso de vehículo");
                Console.WriteLine("2. Consultar hora de salida y permanencia");
                Console.WriteLine("3. Mostrar ingresos por tipo de vehículo");
                Console.WriteLine("4. Mostrar vehículo con mayor permanencia");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción no válida.");
                    continue;
                }

                switch (opcion)
                {
                    case 1: // REGISTRAR INGRESO
                        if (totalIngresos >= MAX_INGRESOS)
                        {
                            Console.WriteLine("¡Límite diario alcanzado (40 vehículos)!");
                            break;
                        }

                        Console.WriteLine($"\n--- Registro #{totalIngresos + 1} ---");
                        
                        Console.Write("Ingrese la placa del vehículo: ");
                        string placaNueva = Console.ReadLine().ToUpper();

                        // Validación: Impedir ingreso duplicado sin salida registrada
                        bool existe = false;
                        for (int i = 0; i < totalIngresos; i++)
                        {
                            if (placas[i] == placaNueva)
                            {
                                existe = true;
                                break;
                            }
                        }

                        if (existe)
                        {
                            Console.WriteLine("Error: Este vehículo ya se encuentra registrado.");
                            break;
                        }

                        placas[totalIngresos] = placaNueva;

                        Console.Write("Ingrese la Torre visitada: ");
                        torres[totalIngresos] = Console.ReadLine();

                        Console.Write("Ingrese el número de Apartamento: ");
                        apartamentos[totalIngresos] = Console.ReadLine();

                        Console.Write("Ingrese el tipo de vehículo (Carro, Moto, Bicicleta): ");
                        tiposVehiculo[totalIngresos] = Console.ReadLine();

                        Console.Write("Ingrese la hora de ingreso (0 a 23): ");
                        horasIngreso[totalIngresos] = double.Parse(Console.ReadLine());

                        Console.Write("Ingrese el tiempo de permanencia estimado (en horas): ");
                        tiemposPermanencia[totalIngresos] = double.Parse(Console.ReadLine());

                        totalIngresos++;
                        Console.WriteLine("¡Ingreso registrado con éxito!");
                        break;

                    case 2: // CONSULTAR SALIDA Y PERMANENCIA
                        Console.Write("\nIngrese la placa a consultar: ");
                        string placaBuscar = Console.ReadLine().ToUpper();
                        bool encontrado = false;

                        for (int i = 0; i < totalIngresos; i++)
                        {
                            if (placas[i] == placaBuscar)
                            {
                                double horaSalida = (horasIngreso[i] + tiemposPermanencia[i]) % 24;
                                Console.WriteLine($"\nVehículo Placa: {placas[i]}");
                                Console.WriteLine($"Hora de Ingreso: {horasIngreso[i]}:00 hrs");
                                Console.WriteLine($"Tiempo de Permanencia: {tiemposPermanencia[i]} horas");
                                Console.WriteLine($"Hora estimada de salida: {horaSalida:00}:00 hrs");
                                encontrado = true;
                                break;
                            }
                        }

                        if (!encontrado)
                        {
                            Console.WriteLine("Vehículo no encontrado en el sistema.");
                        }
                        break;

                    case 3: // CANTIDAD DE INGRESOS POR TIPO
                        int carros = 0, motos = 0, bicis = 0, otros = 0;

                        for (int i = 0; i < totalIngresos; i++)
                        {
                            string tipo = tiposVehiculo[i].ToLower();
                            if (tipo == "carro") carros++;
                            else if (tipo == "moto") motos++;
                            else if (tipo == "bicicleta" || tipo == "bici") bicis++;
                            else otros++;
                        }

                        Console.WriteLine("\n=== ESTADÍSTICAS POR TIPO DE VEHÍCULO ===");
                        Console.WriteLine($"Carros: {carros}");
                        Console.WriteLine($"Motos: {motos}");
                        Console.WriteLine($"Bicicletas: {bicis}");
                        if (otros > 0) Console.WriteLine($"Otros: {otros}");
                        Console.WriteLine($"Total registrados hoy: {totalIngresos}");
                        break;

                    case 4: // VEHÍCULO CON MAYOR PERMANENCIA
                        if (totalIngresos == 0)
                        {
                            Console.WriteLine("No hay vehículos registrados.");
                            break;
                        }

                        int posMayor = 0;
                        double maxPermanencia = tiemposPermanencia[0];

                        for (int i = 1; i < totalIngresos; i++)
                        {
                            if (tiemposPermanencia[i] > maxPermanencia)
                            {
                                maxPermanencia = tiemposPermanencia[i];
                                posMayor = i;
                            }
                        }

                        Console.WriteLine("\n=== VEHÍCULO CON MAYOR PERMANENCIA ===");
                        Console.WriteLine($"Placa: {placas[posMayor]}");
                        Console.WriteLine($"Tipo: {tiposVehiculo[posMayor]}");
                        Console.WriteLine($"Torre: {torres[posMayor]} - Apto: {apartamentos[posMayor]}");
                        Console.WriteLine($"Permanencia: {tiemposPermanencia[posMayor]} horas");
                        break;

                    case 5:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } while (opcion != 5);
        }
    }
}