// See https://aka.ms/new-console-template for more information
using PersonajeCaracteristicas;

Console.WriteLine("Hello, World!");

var fabrica = new FabricaDePersonaje();
var personajes = new List<Personaje>();
for(int i=0; i< 10;i++){
    personajes.Add(fabrica.CrearPersonaje());
}

foreach(var item in personajes){
    item.MostraPersonaje();
}
