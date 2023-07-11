// See https://aka.ms/new-console-template for more information
using PersonajeCaracteristicas;

List<Personaje> nuevaLisa = CrearOBuscarArchivo();
/*
foreach(var item in nuevaLisa){
    item.MostraPersonaje();
}*/
FuncionBatallaParejas(0,1,2);



List<Personaje> CrearOBuscarArchivo(){
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
    return nuevaLisa;
}

void FuncionBatallaParejas(int k, int j, int max){
    int jini = j;
    // problema como dividir los personajes puede ser los 5 primeros para Jugador 1 y los otros 5 para jugador 2
    // int k=0; // 5 primeros personajes para el primer jugador
    // int j=5; // 5 personajes para el segundo a partir del 5to
    int t,b=1; // variable del turno
    int ataque,efecitvidad,defenza,constante = 500, dañoProvocado;
    while(k < j && j < max){
        Console.WriteLine("Jugador 1:");
        nuevaLisa[k].MostraPersonaje();
        Console.WriteLine();
        Console.WriteLine("Jugador 2:");
        nuevaLisa[j].MostraPersonaje();
        Console.WriteLine();
        
        t=1;
        Console.ReadKey();
        Console.Clear();
        
        while(nuevaLisa[k].Salud > 0 && nuevaLisa[j].Salud > 0 ){
            Console.WriteLine("Batalla "+b+"\n");    
            Console.WriteLine("Turno "+t);
            if(t%2 == 0){
                ataque = nuevaLisa[j].Destreza * nuevaLisa[j].Fuerza * nuevaLisa[j].Nivel;
                efecitvidad = FabricaDePersonaje.ObtenerIntRandom(1,100);
                defenza = nuevaLisa[k].Armadura * nuevaLisa[k].Velocidad;
                dañoProvocado = ((ataque*efecitvidad)-defenza)/constante;
                nuevaLisa[k].Salud -= dañoProvocado;
                Console.WriteLine("Atacante:");
                Console.WriteLine("\tJugador 2:");
                nuevaLisa[j].MostraPersonaje();
                Console.WriteLine();
                Console.WriteLine("Daño causado: "+dañoProvocado);
                Console.WriteLine();
                Console.WriteLine("Defensor:");
                Console.WriteLine("\tJugador 1:");
                nuevaLisa[k].MostraPersonaje();
                Console.WriteLine();
                Console.WriteLine("Salud del jugador 1: "+nuevaLisa[k].Salud);
            }else{
                ataque = nuevaLisa[k].Destreza * nuevaLisa[k].Fuerza * nuevaLisa[k].Nivel;
                efecitvidad = FabricaDePersonaje.ObtenerIntRandom(1,100);
                defenza = nuevaLisa[j].Armadura * nuevaLisa[j].Velocidad;
                dañoProvocado = ((ataque*efecitvidad)-defenza)/constante;
                nuevaLisa[j].Salud -= dañoProvocado;
                Console.WriteLine("Atacante:");
                 Console.WriteLine("\tJugador 1:");
                nuevaLisa[k].MostraPersonaje();
                Console.WriteLine();
                Console.WriteLine("Daño causado: "+dañoProvocado);
                Console.WriteLine();
                Console.WriteLine("Defensor:");
                 Console.WriteLine("\tJugador 2:");
                nuevaLisa[j].MostraPersonaje();
                Console.WriteLine();
                Console.WriteLine("Salud del jugador 2: "+nuevaLisa[j].Salud);
            }
            t++;
            Console.WriteLine("\nPresione enter para pasar de turno.");
            Console.ReadKey();
            Console.Clear();

        }
        if(nuevaLisa[k].Salud <= 0){
            Console.WriteLine("Personaje "+ nuevaLisa[k].Nombre +" del Juegador 1 destruido.");
            Console.WriteLine("Personaje "+ nuevaLisa[j].Nombre +" del Jugador 2 recupera o suma 10 de salud y 5 de armadura.");
            k++;
            nuevaLisa[j].Salud +=10;
            nuevaLisa[j].Armadura +=5;
        }else{
            Console.WriteLine("Personaje "+ nuevaLisa[j].Nombre +" del Juegador 2 destruido.");
            Console.WriteLine("Personaje "+ nuevaLisa[k].Nombre +" del Jugador 1 recupera 10 de salud y suma 5 de armadura.");
            j++;
            nuevaLisa[k].Salud +=10;
            nuevaLisa[k].Armadura +=5;
        }
        Console.WriteLine("Presione enter para continuar.");
        Console.ReadKey();
        Console.Clear();
        b++;
    }

    Console.WriteLine();
    if(k >= jini && j <= max){
        Console.WriteLine("Ganandor jugador 2");
    }else{
        Console.WriteLine("Ganador jugador 1");
    }
}