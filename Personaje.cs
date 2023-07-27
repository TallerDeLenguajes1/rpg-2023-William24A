using System.Text.Json;



using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using ClassPokemonName;

namespace PersonajeCaracteristicas;

public class Personaje{
    private string? tipo;
    private string? nombre;
    private int id;
    private DateTime fechanacimiento;
    private int velocidad;
    private int destreza;
    private int fuerza;
    private int nivel;
    private int armadura;
    private int salud;
    private string? abilidad;

    public Personaje(string tipo, string nombre, int ID, DateTime fechanacimiento, int valocidad, int destreza, int fuerza, int nivel, int armadura, int salud, string abilidad)
    {
        this.Tipo = tipo;
        this.Nombre = nombre;
        this.id = ID;
        this.Fechanacimiento = fechanacimiento;
        this.Velocidad = velocidad;
        this.Destreza = destreza;
        this.Fuerza = fuerza;
        this.Nivel = nivel;
        this.Armadura = armadura;
        this.Salud = salud;
        this.Abilidad = abilidad;
    }

    public Personaje(){

    }

    public string? Tipo { get => tipo; set => tipo = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public int ID { get => id; set => id = value; }
    public DateTime Fechanacimiento { get => fechanacimiento; set => fechanacimiento = value; }
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Salud { get => salud; set => salud = value; }
    public string? Abilidad{ get => abilidad; set => abilidad = value; }

    public void MostraPersonaje(){
        Console.WriteLine("\t\tTipo: "+ Tipo);
        Console.WriteLine("\t\tNombre: "+ Nombre);
        Console.WriteLine("\t\tID: "+ ID);
        Console.WriteLine("\t\tFecha de nacimiento: "+Fechanacimiento.ToString("d"));
        Console.WriteLine("\t\tVelocidad: "+Velocidad);
        Console.WriteLine("\t\tDestreza: "+Destreza);
        Console.WriteLine("\t\tFuerza: "+Fuerza);
        Console.WriteLine("\t\tNivel: "+Nivel);
        Console.WriteLine("\t\tArmadura: "+Armadura);
        Console.WriteLine("\t\tSalud: "+Salud);
    }
}

//Crea el personaje 
public static class FabricaDePersonaje{
    public static Personaje CrearPersonaje(){
        var personajeAleatorio = new Personaje();
        var Poke = GetPokemon(ObtenerIntRandom(1,200));
        personajeAleatorio.Tipo = Poke.types[0].type.name;
        personajeAleatorio.Nombre = Poke.name;
        
        personajeAleatorio.ID = Poke.id;
        personajeAleatorio.Fechanacimiento = fechaAleatoria(personajeAleatorio.Tipo);
        personajeAleatorio.Abilidad = Poke.abilities[ObtenerIntRandom(0, Poke.abilities.Count)].ability.name;
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
        anio = ObtenerIntRandom(1724, 2023);
        dia = ObtenerIntRandom(1,29);
        mes = ObtenerIntRandom(1,13);
       
        
        DateTime fecha = new DateTime(anio, mes, dia);
        return fecha;
    }

    // public static int ObtenerEdad(DateTime fecha){
    //     if(fecha < DateTime.Today){
    //         int edad = DateTime.Today.Year - fecha.Year;
    //         if(fecha.Month > DateTime.Today.Month ){
    //             --edad;
    //         }
    //         return edad;
    //     }else{
    //         return -1;
    //     }
    // }

        public static Root GetPokemon(int numero)
            {
                var url = $"https://pokeapi.co/api/v2/pokemon/{numero}/";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null) return null;
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                Root Pokemon = JsonSerializer.Deserialize<Root>(responseBody);
                                return Pokemon;
                                
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    Console.WriteLine("Problemas de acceso a la API");
                    return null;
                }
            }
}

//Manejo de archivo JSON
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
            //string pathJSON = Directory.GetCurrentDirectory()+nuevo;
            
            // if(File.Exists(pathJSON)){
            //      lista = LeerPersonajes(nuevo);
            //      if(lista != null){
            //          return true;
            //      }else{
            //          return false;
            //      }
            //  }else{
            //      return false;
            //  }

            string pathJSON = Directory.GetCurrentDirectory()+nuevo;
            if(File.Exists(pathJSON)){
                    using( StreamReader sw = new StreamReader(pathJSON)){
                    string archivoSalida;
                    if((archivoSalida= sw.ReadLine()) != null){
                     return true;
                    }else{
                        return false;
                    } 
                }
            }else{
                return false;
            }
            
        }
}
