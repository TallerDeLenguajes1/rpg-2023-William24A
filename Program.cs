// See https://aka.ms/new-console-template for more information
using PersonajeCaracteristicas;

Console.WriteLine("Hello, World!");

var personajes = new List<Personaje>();
for(int i=0; i< 10;i++){
    personajes.Add(FabricaDePersonaje.CrearPersonaje());
}
string nombreArchivo = @"\Personajes.json";
PersonajeJson.GuardarPersonajes(personajes, nombreArchivo);

if(PersonajeJson.Existe(nombreArchivo)){
    Console.WriteLine("Existe");
    List<Personaje> nuevaLisa = new List<Personaje>();
    nuevaLisa = PersonajeJson.LeerPersonajes(nombreArchivo);
    foreach(var item in nuevaLisa){
        item.MostraPersonaje();
    }
}else{
    Console.WriteLine("No existe");
}




