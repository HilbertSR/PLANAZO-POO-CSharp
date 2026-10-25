using System;
class Program {
    static void Main() {
        int opcion = 0;

        GestorReservas gestor = new GestorReservas();

        do
        {
            Console.Clear();
            Console.WriteLine("\n------------- PLANAZO - EVENTOS -------------");
            Console.WriteLine(" 1. Ver eventos disponibles");
            Console.WriteLine(" 2. Consultar evento");
            Console.WriteLine(" 3. Registrar usuario");
            Console.WriteLine(" 4. Mostrar usuarios");
            Console.WriteLine(" 5. Reservar entradas");
            Console.WriteLine(" 6. Ver reservas realizadas");
            Console.WriteLine(" 7. Cancelar una reserva");
            Console.WriteLine(" 8. Ver reservas de un usuario");
            Console.WriteLine(" 9. Ver resumen de reservas");
            Console.WriteLine(" 0. Salir");
            Console.WriteLine("---------------------------------------------");

            try{
                Console.Write("\nIngresa una opcion: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)){
                    throw new Exception("Debe ingresar un numero entero");
                }

                if (opcion < 0 || opcion > 9){
                    throw new Exception("La opcion debe estar entre 0 y 8");
                }
            }
            catch (Exception ex){
                Console.WriteLine($"\nError: {ex.Message}");
                Console.ReadKey();

                opcion = -1;
                continue;
            }

            switch (opcion)
            {
                case 0:
                    Console.WriteLine("\nSaliendo de la aplicacion, Adios");
                    Console.Write("\nPresione una tecla para cerrar");
                    Console.ReadKey();
                    break;

                case 1:
                    Console.Clear();
                    Console.WriteLine("\n--------- Eventos Disponibles ---------");

                    foreach (Evento evento in gestor.ObtenerEventos())
                    {
                        evento.MostrarEvento();
                    }
                    Console.Write("\nPresione una tecla para continuar");
                    Console.ReadKey();
                    break;

                case 2:
                    Console.Clear();
                    try{
                        Console.WriteLine("\n--------- Consultar Eventos ---------");
                        int id = LeerEntero("\nID del evento: ");
                        Evento evento = gestor.BuscarEvento(id);
                        evento.MostrarEvento();
                    }
                    catch (Exception ex){
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    Console.Write("\nPresione una tecla para continuar");
                    Console.ReadKey();
                    break;

                case 3:
                    try
                    {
                        Console.WriteLine("\n--------- Crear Usuario ---------");
                        Console.Write("\nNombre del usuario: ");
                        string nombre = Console.ReadLine() ?? "";

                        Usuario u = gestor.CrearUsuario(nombre);
                        u.MostrarUsuario();
                        Console.WriteLine("\nUsuario creado");
                    }
                    catch (Exception ex){
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    Console.Write("\nPresione una tecla para continuar");
                    Console.ReadKey();
                    break;

                case 4:
                    try{
                        Console.WriteLine("\n--------- Usuarios Creados ---------");
                        if (gestor.ObtenerUsuario().Count == 0)
                        {
                            Console.WriteLine("\n No hay usuarios creados");
                            Console.WriteLine("\n---------------------------------------");
                        }
                        else{
                            foreach (Usuario usuario in gestor.ObtenerUsuario())
                            {
                                usuario.MostrarUsuario();
                            }
                        }
                    }
                    catch (Exception ex){
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    Console.Write("\nPresione una tecla para continuar");
                    Console.ReadKey();
                    break;

                case 5:
                    Console.Clear();
                    try{
                        Console.WriteLine("\n--------- Reservar Evento ---------");

                        int idEvento = LeerEntero("\nID del evento: ");
                        int idUsuario = LeerEntero("\nID del usuario: ");
                        int cantidad = LeerEntero("\nCantidad de entradas: ");

                        Reserva r = gestor.CrearReserva(idEvento, idUsuario, cantidad);
                        r.MostrarReserva();
                        Console.WriteLine("\nReserva realizada");
                    }
                    catch (Exception ex){
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    Console.Write("\nPresione una tecla para continuar");
                    Console.ReadKey();
                    break;

                case 6:
                    Console.Clear();
                    try{
                        Console.WriteLine("\n--------- Reservas Realizadas ---------");
                        if (gestor.ObtenerReservas().Count == 0)
                        {
                            Console.WriteLine("\n No hay reservas");
                            Console.WriteLine("\n---------------------------------------");
                        }
                        else{
                            foreach (Reserva reserva in gestor.ObtenerReservas())
                            {
                                reserva.MostrarReserva();
                            }
                        }
                    }
                    catch (Exception ex){
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    Console.Write("\nPresione una tecla para continuar");
                    Console.ReadKey();
                    break;

                case 7:
                    Console.Clear();
                    try{
                        Console.WriteLine("\n--------- Cancelar Reserva ---------");
                        int id = LeerEntero(" ID de la reserva: ");
                        gestor.CancelarReserva(id);
                        Console.WriteLine("\n Reserva cancelada");
                        Console.WriteLine("\n----------------------------------");
                    }
                    catch (Exception ex){
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    Console.Write("\nPresione una tecla para continuar");
                    Console.ReadKey();
                    break;

                case 8:
                    Console.Clear();
                    try{
                        Console.WriteLine("\n--------- Reservas Usuario ---------");
                        int idUsuario = LeerEntero("\nID del usuario: ");
                        gestor.ObtenerReservasUsuario(idUsuario);
                        if (gestor.ObtenerReservasUsuario(idUsuario).Count == 0)
                        {
                            Console.WriteLine("\n El usuario no tiene reservas");
                            Console.WriteLine("\n---------------------------------------");
                        }
                        else{
                            foreach (Reserva reserva in gestor.ObtenerReservasUsuario(idUsuario))
                            {
                                reserva.MostrarReserva();
                            }
                        }
                        Console.WriteLine("\n------------------------------------");
                    }
                    catch (Exception ex){
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    Console.Write("\nPresione una tecla para continuar");
                    Console.ReadKey();
                    break;

                case 9:
                    Console.Clear();
                    var resumen = gestor.ObtenerResumen();
                    Console.WriteLine("\n------------ RESUMEN DE RESERVAS ------------");
                    Console.WriteLine($"Reservas activas: {resumen.Activas}");
                    Console.WriteLine($"Reservas canceladas: {resumen.Canceladas}");            
                    Console.WriteLine($"Entradas reservadas: {resumen.Entradas}");
                    Console.WriteLine($"Ingresos por reservas activas: {resumen.Total:C}");
                    Console.WriteLine("---------------------------------------------");
                    Console.Write("\nPresione una tecla para continuar");
                    Console.ReadKey();
                    break;
            }
        } while (opcion != 0);
    }

    static int LeerEntero(string mensaje)
    {
        Console.Write(mensaje);

        if (!int.TryParse(Console.ReadLine(), out int valor)){
            throw new ArgumentException("Ingrese un número entero válido");
        }
        return valor;
    }
}