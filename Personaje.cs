namespace PersonajeCaracteristicas;

public class Personaje{
    private string tipo;
    private string nombre;
    private string apodo;
    private DateTime fechanacimiento;
    private int valocidad;
    private int destreza;
    private int fuerza;
    private int nivel;
    private int armadura;
    private int salud;

    public Personaje(string tipo, string nombre, string apodo, DateTime fechanacimiento, int valocidad, int destreza, int fuerza, int nivel, int armadura, int salud)
    {
        this.Tipo = tipo;
        this.Nombre = nombre;
        this.Apodo = apodo;
        this.Fechanacimiento = fechanacimiento;
        this.Valocidad = valocidad;
        this.Destreza = destreza;
        this.Fuerza = fuerza;
        this.Nivel = nivel;
        this.Armadura = armadura;
        this.Salud = salud;
    }

    public string Tipo { get => tipo; set => tipo = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }
    public DateTime Fechanacimiento { get => fechanacimiento; set => fechanacimiento = value; }
    public int Valocidad { get => valocidad; set => valocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Salud { get => salud; set => salud = value; }
}
