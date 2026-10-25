using System;
class Cine : Evento
{
    public Cine(int id, string nombre, string fecha, decimal precio, int capacidad)
        : base(id, nombre, fecha, precio, capacidad)
    {
        
    }

    public override decimal CalcularPrecioFinal()
    {
        return PrecioBase;
    }
}