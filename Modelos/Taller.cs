using System;

class Taller:Evento
{
    public Taller(int id, string nombre, string fecha, decimal precio, int capacidad)
        : base(id, nombre, fecha, precio, capacidad)
    {
        
    }

    public override decimal CalcularPrecioFinal()
    {
        decimal valor = (PrecioBase * 10) / 100;
        decimal valorTaller = PrecioBase - valor;

        return valorTaller;
    }
}