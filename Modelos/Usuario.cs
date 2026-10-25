class Usuario
{
    public int Identificador { get; private set; }
    public string Nombre { get; private set; }

    public Usuario(int id, string nombre)
    {
        if (id <= 0)
            throw new ArgumentException("El identificador debe ser mayor que cero.");

        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre no puede estar vacío.");

        Identificador = id;
        Nombre = nombre;
    }

    public void MostrarUsuario()
    {
        Console.WriteLine("\n-------------- Usuario --------------");
		Console.WriteLine($"ID: {Identificador}");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine("--------------------------------------");
    }
}