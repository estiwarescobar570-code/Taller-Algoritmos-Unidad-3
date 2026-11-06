using System;

class Program
{
    static void Main()
    {
        // 1. Declaración de variables
        double codigo;
        string nombre;
        double notasPar;
        double asistencias;
        double definitiva;

        // Variables de control de grupo
        int nclases = 20;
        double mejorPromedio = 0;
        double peorPromedio = 5.0;

        Console.WriteLine("=== INGRESO DE INFORMACIÓN DEL ESTUDIANTE ===");

        Console.Write("Ingrese el Código del estudiante: ");
        codigo = double.Parse(Console.ReadLine());

        Console.Write("Ingrese el Nombre del estudiante: ");
        nombre = Console.ReadLine();

        Console.Write("Ingrese la Nota Parcial (0.0 a 5.0): ");
        notasPar = double.Parse(Console.ReadLine());

        // 2. Validación inmediata de la nota
        if (notasPar < 0.0 || notasPar > 5.0)
        {
            Console.WriteLine("Error: La nota ingresada no es válida. Debe estar entre 0.0 y 5.0.");
            return; // Detiene la ejecución si el dato es incorrecto
        }

        Console.Write("Ingrese las Asistencias del estudiante (0 a 5.0): ");
        asistencias = double.Parse(Console.ReadLine());

        // 3. Procesamiento y Cálculo
        definitiva = (notasPar * 0.7) + (asistencias * 0.3);

        // 4. Mostrar Resultados
        Console.WriteLine("\n=== INFORMACIÓN DEL ESTUDIANTE ===");
        Console.WriteLine("Código: " + codigo);
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Nota Parcial: " + notasPar);
        Console.WriteLine("Asistencias: " + asistencias);
        Console.WriteLine("Nota Definitiva: " + definitiva);

        // 5. Determinar el estado del estudiante
        if (definitiva >= 3.0)
        {
            Console.WriteLine("Estado: El estudiante ha aprobado.");
        }
        else if (definitiva >= 2.8) // Entre 2.8 y 2.99
        {
            Console.WriteLine("Estado: El estudiante está en periodo de recuperación.");
        }
        else
        {
            Console.WriteLine("Estado: El estudiante ha reprobado.");
        }

        // 6. Porcentaje de asistencias con respecto al total de clases
        double porcentajeAsistencias = (asistencias / nclases) * 100;
        Console.WriteLine("Porcentaje de asistencia al curso: " + porcentajeAsistencias + "%");
    }
}