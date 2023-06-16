namespace PersonajeCaracteristicas;

public class Personaje{
    private string tipo;
    private string nombre;
    private string apodo;
    private DateTime fechanacimiento;
    private int velocidad;
    private int destreza;
    private int fuerza;
    private int nivel;
    private int armadura;
    private int salud;
    private int edad;

    public Personaje(string tipo, string nombre, string apodo, DateTime fechanacimiento, int valocidad, int destreza, int fuerza, int nivel, int armadura, int salud, int edad)
    {
        this.Tipo = tipo;
        this.Nombre = nombre;
        this.Apodo = apodo;
        this.Fechanacimiento = fechanacimiento;
        this.Velocidad = velocidad;
        this.Destreza = destreza;
        this.Fuerza = fuerza;
        this.Nivel = nivel;
        this.Armadura = armadura;
        this.Salud = salud;
        this.Edad = edad;
    }

    public Personaje(){

    }

    public string Tipo { get => tipo; set => tipo = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }
    public DateTime Fechanacimiento { get => fechanacimiento; set => fechanacimiento = value; }
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Salud { get => salud; set => salud = value; }
    public int Edad { get => salud; set => salud = value; }
}

public class FabricaDePersonaje{
    public Personaje CrearPersonaje(){
        var personajeAleatorio = new Personaje();
        personajeAleatorio.Nombre = ObtenerNombre();
        personajeAleatorio.Tipo = ObtenerTipo();
        personajeAleatorio.Apodo = ObtenerApodo();
        personajeAleatorio.Fechanacimiento = fechaAleatoria();
        personajeAleatorio.Edad = ObtenerEdad(personajeAleatorio.Fechanacimiento);
        personajeAleatorio.Velocidad = ObtenerIntRandom(1,10);
        personajeAleatorio.Destreza =ObtenerIntRandom(1,5);
        personajeAleatorio.Fuerza = ObtenerIntRandom(1,10);
        personajeAleatorio.Nivel= 1;
        personajeAleatorio.Armadura = ObtenerIntRandom(1,10);
        personajeAleatorio.Salud = 100;

        return personajeAleatorio;
    }

    public int ObtenerIntRandom(int ini,int  fin){
        var random = new Random();
        return random.Next(ini,fin);
    }

    public string ObtenerNombre(){
        var nombres = new string[3] {"Raul", "Mauro", "Messi" };
        var elegir = ObtenerIntRandom(0,3);
        return nombres[elegir];
    }

    public string ObtenerTipo(){
        var tipo = new string[3] {"Humano", "Orco", "Elfo"};
        var elegir = ObtenerIntRandom(0,3);
        return tipo[elegir];
    }

    public string ObtenerApodo(){
        var apodo = new string[3] { "El tronco","Pancho", "Dios"};
        var elegir = ObtenerIntRandom(0,3);
        return apodo[elegir];
    }

    public DateTime fechaAleatoria(){
        int dia , mes, anio;
        dia = ObtenerIntRandom(1,29);
        mes = ObtenerIntRandom(1,13);
        anio = ObtenerIntRandom(1725, 2023);
        DateTime fecha = new DateTime(anio, mes, dia);
        return fecha;
    }

    public int ObtenerEdad(DateTime fecha){
        if(fecha < DateTime.Today){
            int edad = DateTime.Today.Year - fecha.Year;
            if(fecha.Month > DateTime.Today.Month ){
                --edad;
            }
            return edad;
        }else{
            return -1;
        }
    }
}

