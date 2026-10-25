using System;

class Concierto:Evento
{
    public Concierto(int id, string nombre, string fecha, decimal precio, int capacidad)
        : base(id, nombre, fecha, precio, capacidad)
    {
        
    }

    public override decimal CalcularPrecioFinal()
    {
        decimal valor = (PrecioBase * 15) / 100;
        decimal valorConcierto = PrecioBase + valor;

        return valorConcierto;
    }
}