using System;

class Festival:Evento
{
    public Festival(int id, string nombre, string fecha, decimal precio, int capacidad)
        : base(id, nombre, fecha, precio, capacidad)
    {
        
    }

    public override decimal CalcularPrecioFinal()
    {
        decimal valor = (PrecioBase * 10) / 100;
        decimal valorFestival = PrecioBase + valor;

        return valorFestival;
    }
}