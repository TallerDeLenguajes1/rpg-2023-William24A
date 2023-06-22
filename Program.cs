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
/*
foreach(var item in nuevaLisa){
    item.MostraPersonaje();
}*/


// problema como dividir los personajes puede ser los 5 primeros para Jugador 1 y los otros 5 para jugador 2
int k=0; // 5 primeros personajes para el primer jugador
int j=5; // 5 personajes para el segundo a partir del 5to
int t,b=1; // variable del turno
int ataque,efecitvidad,defenza,constante = 500, dañoProvocado;
while(k < 5 && j < 10){
    Console.WriteLine("Jugador 1:");
    nuevaLisa[k].MostraPersonaje();
    Console.WriteLine();
    Console.WriteLine("Jugador 2:");
    nuevaLisa[j].MostraPersonaje();
    Console.WriteLine();
    Console.WriteLine("Batalla "+b+"\n");
    t=1;
    while(nuevaLisa[k].Salud > 0 && nuevaLisa[j].Salud > 0 ){
        Console.WriteLine("Turno "+t);
        if(t%2 == 0){
            ataque = nuevaLisa[j].Destreza * nuevaLisa[j].Fuerza * nuevaLisa[j].Nivel;
            efecitvidad = FabricaDePersonaje.ObtenerIntRandom(1,100);
            defenza = nuevaLisa[k].Armadura * nuevaLisa[k].Velocidad;
            dañoProvocado = ((ataque*efecitvidad)-defenza)/constante;
            nuevaLisa[k].Salud -= dañoProvocado;
            Console.WriteLine("Daño causado: "+dañoProvocado);
            Console.WriteLine("Salud del jugador 1: "+nuevaLisa[k].Salud);
        }else{
            ataque = nuevaLisa[k].Destreza * nuevaLisa[k].Fuerza * nuevaLisa[k].Nivel;
            efecitvidad = FabricaDePersonaje.ObtenerIntRandom(1,100);
            defenza = nuevaLisa[j].Armadura * nuevaLisa[j].Velocidad;
            dañoProvocado = ((ataque*efecitvidad)-defenza)/constante;
            nuevaLisa[j].Salud -= dañoProvocado;
            Console.WriteLine("Daño causado: "+dañoProvocado);
            Console.WriteLine("Salud del jugador 2: "+nuevaLisa[j].Salud);
        }
        t++;
        Console.WriteLine();
    }
    if(nuevaLisa[k].Salud <= 0){
        k++;
        nuevaLisa[j].Salud +=10;
        nuevaLisa[j].Armadura +=5;
    }else{
        j++;
        nuevaLisa[k].Salud +=10;
        nuevaLisa[k].Armadura +=5;
    }
    b++;
}
Console.WriteLine();
if(k > 4 && j < 10){
    Console.WriteLine("Ganandor jugador 2");
}else{
    Console.WriteLine("Ganador jugador 1");
}
