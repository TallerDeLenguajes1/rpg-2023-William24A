using System.Text.Json;
namespace PersonajeCaracteristicas;

public class Personaje{
    private string? tipo;
    private string? nombre;
    private string? apodo;
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

    public string? Tipo { get => tipo; set => tipo = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Apodo { get => apodo; set => apodo = value; }
    public DateTime Fechanacimiento { get => fechanacimiento; set => fechanacimiento = value; }
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Salud { get => salud; set => salud = value; }
    public int Edad { get => edad; set => edad = value; }

    public void MostraPersonaje(){
        Console.WriteLine("Tipo: "+ Tipo);
        Console.WriteLine("Nombre: "+ Nombre);
        Console.WriteLine("Apodo: "+Apodo);
        Console.WriteLine("Fecha de nacimiento: "+Fechanacimiento);
        Console.WriteLine("Velocidad: "+Velocidad);
        Console.WriteLine("Destreza: "+Destreza);
        Console.WriteLine("Fuerza: "+Fuerza);
        Console.WriteLine("Niverl: "+Nivel);
        Console.WriteLine("Armadura: "+Armadura);
        Console.WriteLine("Salud: "+Salud);
        Console.WriteLine("Edad: "+Edad);
    }
}

public static class Obtener{
    public static string[] NombreH ={"Raul", "Mauro", "Messi"};
    public static string[] NombreO = {"Groud","Traurus","Marcus"};
    public static string[] NombreE = {"Elif", "Serif", "Eliot"};
    public static string NombreA(string tipo){
        string nombre= " ";
        switch(tipo){
            case "Humano":
                nombre = NombreH[FabricaDePersonaje.ObtenerIntRandom(1,3)];
                break;
            case "Orco":
                nombre = NombreO[FabricaDePersonaje.ObtenerIntRandom(1,3)];
                break;
            case "Elfo":
                nombre = NombreE[FabricaDePersonaje.ObtenerIntRandom(1,3)];
                break;
        }
        return nombre;
    }
    public static string[] Tipo = {"Humano", "Orco", "Elfo"};
    
    public static string[] ApodoH = {"Veloz", "Dios de guerra", "El que sobrevive"};
    public static string[] ApodoO = {"De la orda", "El inmortal", "Destruccion"};
    public static string[] ApodoE = {"El viento", "Flecha veloz", "Rayo"};
    public static string ApodoA(string tipo){
        string apodo= " ";
        switch(tipo){
            case "Humano":
                apodo = ApodoH[FabricaDePersonaje.ObtenerIntRandom(0,3)];
                break;
            case "Orco":
                apodo = ApodoO[FabricaDePersonaje.ObtenerIntRandom(0,3)];
                break;
            case "Elfo":
                apodo = ApodoE[FabricaDePersonaje.ObtenerIntRandom(0,3)];
                break;
        }
        return apodo;
    }
}

public static class FabricaDePersonaje{
    public static Personaje CrearPersonaje(){
        var personajeAleatorio = new Personaje();
        personajeAleatorio.Tipo = Obtener.Tipo[ObtenerIntRandom(0,3)];
        personajeAleatorio.Nombre = Obtener.NombreA(personajeAleatorio.Tipo);
        personajeAleatorio.Apodo = Obtener.ApodoA(personajeAleatorio.Tipo);
        personajeAleatorio.Fechanacimiento = fechaAleatoria(personajeAleatorio.Tipo);
        personajeAleatorio.Edad = ObtenerEdad(personajeAleatorio.Fechanacimiento);
        personajeAleatorio.Velocidad = ObtenerIntRandom(1,10);
        personajeAleatorio.Destreza =ObtenerIntRandom(1,5);
        personajeAleatorio.Fuerza = ObtenerIntRandom(1,10);
        personajeAleatorio.Nivel= ObtenerIntRandom(1,10);
        personajeAleatorio.Armadura = ObtenerIntRandom(1,10);
        personajeAleatorio.Salud = 100;

        return personajeAleatorio;
    }

    public static int ObtenerIntRandom(int ini,int  fin){
        var random = new Random();
        return random.Next(ini,fin);
    }

    public static DateTime fechaAleatoria(string tipo){
        int dia , mes, anio;
        if(tipo == "Humano"){
             anio = ObtenerIntRandom(1933, 2023);
        }else{
             anio = ObtenerIntRandom(1724, 2023);
        }
        dia = ObtenerIntRandom(1,29);
        mes = ObtenerIntRandom(1,13);
       
        
        DateTime fecha = new DateTime(anio, mes, dia);
        return fecha;
    }

    public static int ObtenerEdad(DateTime fecha){
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

public static class PersonajeJson{
              
        public static void GuardarPersonajes(List<Personaje> nuevo, string archivo){
            
            string Json = JsonSerializer.Serialize<List<Personaje>>(nuevo);
            string pathJSON = Directory.GetCurrentDirectory()+archivo;
            using(StreamWriter sw = new StreamWriter(pathJSON, false)){
                sw.Write(Json);
                sw.Close();
            }
        }

        public static List<Personaje> LeerPersonajes(string archivo){
            List<Personaje> listPer = new List<Personaje>();
            string pathJSON = Directory.GetCurrentDirectory()+archivo;
            string Json = File.ReadAllText(pathJSON); //Leer archivo y guardar

            listPer = JsonSerializer.Deserialize<List<Personaje>>(Json); // aclaracion de lista
            
            return listPer;
        }

        public static bool Existe(string nuevo){
            var lista = new List<Personaje>();
            
            // if(File.Exists(nuevo)){
            //     lista = LeerPersonajes(nuevo);
            //     if(lista != null){
            //         return true;
            //     }else{
            //         return false;
            //     }
            // }else{
            //     return false;
            // }
            string pathJSON = Directory.GetCurrentDirectory()+nuevo;
            using( StreamReader sw = new StreamReader(pathJSON)){
                 string archivoSalida;
                if((archivoSalida= sw.ReadLine()) != null){
                    return true;
                }else{
                    return false;
                } 
            }
           

        }
}

