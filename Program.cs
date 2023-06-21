// See https://aka.ms/new-console-template for more information
using PersonajeCaracteristicas;

string nombreArchivo = @"\Personajes.json";
List<Personaje> nuevaLisa = new List<Personaje>();

if(PersonajeJson.Existe(nombreArchivo)){
    Console.WriteLine("Existe");    
    nuevaLisa = PersonajeJson.LeerPersonajes(nombreArchivo);
}else{
    for(int i=0; i< 10;i++){
        nuevaLisa.Add(FabricaDePersonaje.CrearPersonaje());
        PersonajeJson.GuardarPersonajes(nuevaLisa, nombreArchivo);
    }
}

foreach(var item in nuevaLisa){
    item.MostraPersonaje();
}




