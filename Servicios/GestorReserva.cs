using System;
class GestorReservas
{
    private readonly List<Evento> eventos = new List<Evento>();
    private readonly List<Reserva> reservas = new List<Reserva>();
    private readonly List<Usuario> usuarios = new List<Usuario>();
    private int siguienteReserva = 1;
    private int siguienteUsuario = 1;

    public GestorReservas()
    {
        CargarEventos();
    }

    private void CargarEventos()
    {
        eventos.Add(new Cine(1, "Resident Evil", "31/10/2026", 20000, 150));
        eventos.Add(new Cine(2, "Wildwood", "11/11/2026", 10000, 200));
        eventos.Add(new Concierto(3, "Guns and Roses", "25/11/2026", 70000, 10000));
        eventos.Add(new Concierto(4, "AC/DC", "19/12/2026", 56000, 12000));
        eventos.Add(new Taller(5, "Taller de Programacion", "30/10/2026", 7000, 60));
        eventos.Add(new Taller(6, "Taller de Diseño Web", "14/11/2026", 5000, 50));
        eventos.Add(new Festival(7, "Festival de Halloween", "31/10/2026", 25000, 500));
        eventos.Add(new Festival(8, "Festival de Noviembre", "21/11/2026", 15000, 1000));
    }

    public IReadOnlyList<Evento> ObtenerEventos()
    {
        return eventos.AsReadOnly();
    }

    public Evento BuscarEvento(int id)
    {
        Evento? evento = eventos.FirstOrDefault(e => e.Identificador == id);

        if (evento == null)
            throw new KeyNotFoundException("No existe un evento con ese ID.");

        return evento;
    }

    public Usuario CrearUsuario(string nombre)
    {
        Usuario usuario = new Usuario(siguienteUsuario, nombre);

        siguienteUsuario++;
        usuarios.Add(usuario);

        return usuario;
    }

    public IReadOnlyList<Usuario> ObtenerUsuario()
    {
        return usuarios.AsReadOnly();
    }

    public Usuario BuscarUsuario(int id)
    {
        Usuario? usuario = usuarios.FirstOrDefault(u => u.Identificador == id);

        if (usuario == null){
            throw new KeyNotFoundException("No existe un usuario con ese ID.");
        }

        return usuario;
    }

    public IReadOnlyList<Reserva> ObtenerReservasUsuario(int idUsuario){
        Usuario usuario = BuscarUsuario(idUsuario);

        return reservas.Where(r => r.Cliente.Identificador == usuario.Identificador).ToList().AsReadOnly();
    }

    public Reserva CrearReserva(int idEvento, int idUsuario, int cantidad){

        Evento evento = BuscarEvento(idEvento);
        Usuario cliente = BuscarUsuario(idUsuario);

        Reserva reserva = new Reserva(siguienteReserva, cliente, evento, cantidad);

        evento.ReservarCupos(cantidad);

        siguienteReserva++;
        reservas.Add(reserva);

        return reserva;
    }

    public IReadOnlyList<Reserva> ObtenerReservas()
    {
        return reservas.AsReadOnly();
    }

    public Reserva BuscarReserva(int id)
    {
        Reserva? reserva = reservas.FirstOrDefault(r => r.IdentificadorReserva == id);

        if (reserva == null)
            throw new KeyNotFoundException("No existe una reserva con ese ID.");

        return reserva;
    }

    public void CancelarReserva(int idReserva)
    {
        BuscarReserva(idReserva).Cancelar();
    }

    public (int Activas, int Canceladas, int Entradas, decimal Total) ObtenerResumen()
    {
        var activas = reservas.Where(r => r.EstadoReserva).ToList();

        return (activas.Count, reservas.Count - activas.Count, activas.Sum(r => r.CantidadEntradas), activas.Sum(r => r.ValorTotal));
    }
}