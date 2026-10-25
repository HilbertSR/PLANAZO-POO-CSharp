using System;

class Reserva
{
    public int IdentificadorReserva { get; private set; }
    public Usuario Cliente { get; private set; }
    public Evento EventoReservado { get; private set; }
    public int CantidadEntradas { get; private set; }
    public decimal ValorTotal { get; private set; }
    public bool EstadoReserva { get; private set; }

    public Reserva(int id, Usuario cliente, Evento evento, int cantidad)
    {
        if (cliente == null){
            throw new ArgumentNullException(nameof(cliente));
        }

        if (cantidad <= 0){
            throw new ArgumentException("La cantidad debe ser mayor que cero.");
        }

        if (evento == null){
            throw new ArgumentNullException(nameof(evento));
        }

        IdentificadorReserva = id;
        Cliente = cliente;
        EventoReservado = evento;
        CantidadEntradas = cantidad;
        ValorTotal = evento.CalcularPrecioFinal() * cantidad;
        EstadoReserva = true;
    }

    public void Cancelar()
    {
        if (!EstadoReserva){
            throw new InvalidOperationException("La reserva ya está cancelada.");
        }

        EventoReservado.LiberarCupos(CantidadEntradas);
        EstadoReserva = false;
    }

    public void MostrarReserva()
    {
        Console.WriteLine("\n--------------- Reserva ---------------");
        Console.WriteLine($"Reserva: {IdentificadorReserva}");
        Console.WriteLine($"Cliente: {Cliente.Nombre}");
        Console.WriteLine($"Evento: {EventoReservado.Nombre}");
        Console.WriteLine($"Entradas: {CantidadEntradas}");
        Console.WriteLine($"Total: {ValorTotal:C}");
        Console.WriteLine($"Estado: {(EstadoReserva ? "Activa" : "Cancelada")}");
        Console.WriteLine("---------------------------------------");
    }
}