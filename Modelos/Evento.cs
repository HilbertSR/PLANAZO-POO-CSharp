using System;
abstract class Evento{
    public int Identificador { get; private set; }
    public string Nombre { get; private set; }
    public string Fecha { get; private set; }
    public decimal PrecioBase { get; private set; }
    public int CapacidadMaxima { get; private set; }
    public int CuposDisponibles { get; private set; }

    protected Evento(int identificador, string nombre, string fecha, decimal precioBase, int capacidadMaxima)
    {
        if (identificador <= 0){
            throw new ArgumentException("El identificador debe ser mayor que cero.");
        }

        if (string.IsNullOrWhiteSpace(nombre)){
            throw new ArgumentException("El nombre no puede estar vacío.");
        }

        if (string.IsNullOrWhiteSpace(fecha)){
            throw new ArgumentException("La fecha no puede estar vacía.");
        }

        if (precioBase <= 0){
            throw new ArgumentException("El precio debe ser mayor que cero.");
        }

        if (capacidadMaxima <= 0){
            throw new ArgumentException("La capacidad debe ser mayor que cero.");
        }

        Identificador = identificador;
        Nombre = nombre;
        Fecha = fecha;
        PrecioBase = precioBase;
        CapacidadMaxima = capacidadMaxima;
        CuposDisponibles = capacidadMaxima;
    }

    public void MostrarEvento() {
        Console.WriteLine("\n--------------- Evento ---------------");
		Console.WriteLine($"ID: {Identificador}");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Fecha: {Fecha}");
        Console.WriteLine($"Precio base: {PrecioBase:C}");
        Console.WriteLine($"Precio final: {CalcularPrecioFinal():C}");
        Console.WriteLine($"Cupos disponibles: {CuposDisponibles}");
        Console.WriteLine("--------------------------------------");
	}

    public void ReservarCupos(int cantidad){
        if (cantidad <= 0){
            throw new ArgumentException("La cantidad debe ser mayor que cero.");
        }

        if (cantidad > CuposDisponibles){
            throw new InvalidOperationException("No hay cupos suficientes.");
        }

        CuposDisponibles -= cantidad;
    }

    public void LiberarCupos(int cantidad)
    {
        if (cantidad <= 0 ||CuposDisponibles + cantidad > CapacidadMaxima)
        {
            throw new ArgumentException("Cantidad de cupos no válida.");
        }

        CuposDisponibles += cantidad;
    }

    public abstract decimal CalcularPrecioFinal();
}