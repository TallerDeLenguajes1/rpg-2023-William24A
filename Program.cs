// See https://aka.ms/new-console-template for more information
using PersonajeCaracteristicas;

List<Personaje> nuevaList = CrearOBuscarArchivo();
int menu;
do
{   
    Console.Clear();
    menu = Menu(); //Mostrar Menu principal
    Console.WriteLine("Presione enter para continuar.");
    Console.ReadKey();
    Console.Clear();
    switch (menu)
    {
        case 1:
            //Funcion que genera batalla 5 vs 5
            FuncionBatallaParejas(0 , 5 , 10 , nuevaList);
            break;
        case 2:
            //Funcion que genera batalla 3 vs 3
            FuncionBatallaParejas(0 , 3 , 6 , nuevaList);
            break;
        case 3:
            //Funcion que elimina archivo JSON y crea uno nuevo
            nuevaList = EliminarYcrear();
            Console.WriteLine("Nuevos Personajes creados.");
            Console.WriteLine("Presione enter para continuar");
            Console.ReadKey();
            Console.Clear();
            break;
        default:
            Console.Clear();
            Console.WriteLine("Muchas gracias por elegirnos.");
            nuevaList.Clear();
            break;
    }

} while (menu != 4);


// Funcion que elimina si existe un archivo y crea una lista nueva de personajes
List<Personaje> EliminarYcrear(){
    string nombreArchivo = @"Personajes.json";

    if (File.Exists(nombreArchivo))
    {   //Eliminar archivo 
        File.Delete(nombreArchivo);
        Console.WriteLine("Archivo eliminado.");
    }
    
    return CrearOBuscarArchivo();
}


//Funcion que busca si es que existe el archivo JSON o crea personajes y guarda
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


//funcion que genera las batallas entre los personajes
void FuncionBatallaParejas(int k, int j, int max, List<Personaje> nuevaLista){
    int jini = j;
    int t,b=1; // variable del turno
    int ataque,efecitvidad,defenza,constante = 500, dañoProvocado;
    while(k < jini && j < max){
        Console.WriteLine("Jugador 1:");
        nuevaLista[k].MostraPersonaje();
        Console.WriteLine();
        Console.WriteLine("Enemigo:");
        nuevaLista[j].MostraPersonaje();
        Console.WriteLine();
        Console.WriteLine("Presione enter para continuar.");   
        t=1;
        Console.ReadKey();
        Console.Clear();
        
        while(nuevaLista[k].Salud > 0 && nuevaLista[j].Salud > 0 ){
            Console.WriteLine("Batalla "+b+"\n");    
            Console.WriteLine("Turno "+t);
            if(t%2 == 0){
                ataque = nuevaLista[j].Destreza * nuevaLista[j].Fuerza * nuevaLista[j].Nivel;
                efecitvidad = FabricaDePersonaje.ObtenerIntRandom(1,100);
                defenza = nuevaLista[k].Armadura * nuevaLista[k].Velocidad;
                dañoProvocado = ((ataque*efecitvidad)-defenza)/constante;
                nuevaLista[k].Salud -= dañoProvocado;
                Console.WriteLine("Atacante:");
                Console.WriteLine("\tEnemigo:");
                Mensaje(nuevaList[j]);
                nuevaLista[j].MostraPersonaje();
                Console.WriteLine();
                Console.WriteLine("Daño causado: "+dañoProvocado);
                Console.WriteLine();
                Console.WriteLine("Defensor:");
                Console.WriteLine("\tJugador 1:");
                nuevaLista[k].MostraPersonaje();
                Console.WriteLine();
                Console.WriteLine("Salud del jugador 1: "+nuevaLista[k].Salud);
            }else{
                ataque = nuevaLista[k].Destreza * nuevaLista[k].Fuerza * nuevaLista[k].Nivel;
                efecitvidad = FabricaDePersonaje.ObtenerIntRandom(1,100);
                defenza = nuevaLista[j].Armadura * nuevaLista[j].Velocidad;
                dañoProvocado = ((ataque*efecitvidad)-defenza)/constante;
                nuevaLista[j].Salud -= dañoProvocado;
                Console.WriteLine("Atacante:");
                Console.WriteLine("\tJugador 1:");
                Mensaje(nuevaList[k]);
                nuevaLista[k].MostraPersonaje();
                Console.WriteLine();
                Console.WriteLine("Daño causado: "+dañoProvocado);
                Console.WriteLine();
                Console.WriteLine("Defensor:");
                 Console.WriteLine("\tEnemigo:");
                nuevaLista[j].MostraPersonaje();
                Console.WriteLine();
                Console.WriteLine("Salud del Enemigo: "+nuevaLista[j].Salud);
            }
            t++;
            Console.WriteLine("\nPresione enter para pasar de turno.");
            Console.ReadKey();
            Console.Clear();

        }
        if(nuevaLista[k].Salud <= 0){
            Console.WriteLine("Personaje "+ nuevaLista[k].Nombre +" del Juegador 1 destruido.");
            Console.WriteLine("Personaje "+ nuevaLista[j].Nombre +" del Enemigo recupera o suma 10 de salud y 5 de armadura.");
            k++;
            nuevaLista[j].Salud +=10;
            nuevaLista[j].Armadura +=5;
        }else{
            Console.WriteLine("Personaje "+ nuevaLista[j].Nombre +" del Enemigo destruido.");
            Console.WriteLine("Personaje "+ nuevaLista[k].Nombre +" del Jugador 1 recupera 10 de salud y suma 5 de armadura.");
            j++;
            nuevaLista[k].Salud +=10;
            nuevaLista[k].Armadura +=5;
        }
        Console.WriteLine("Presione enter para continuar.");
        Console.ReadKey();
        Console.Clear();
        b++;
    }

    Console.WriteLine();
    if(k >= jini && j <= max){
        Console.WriteLine("Perdiste");
    }else{
        Console.WriteLine("Ganador jugador 1");
    }
    Console.WriteLine("Presione enter para continuar.");
    Console.ReadKey();
    Console.Clear();
}

// Funcion que muestra el menu principal
int Menu(){
    int op;
    do{
    Console.WriteLine("======= MENU =======\n");
    Console.WriteLine("| 1- Batalla 5 vs 5");
    Console.WriteLine("| 2- Batalla 3 vs 3");
    Console.WriteLine("| 3- Cargar nuevos personajes aleatorios");
    Console.WriteLine("| 4- Salir\n");
    Console.Write("Ingresar opcion: ");
    op = IngresarEntero();
    if(op < 1 || op > 4){
        Console.WriteLine("\nOpcion incorrecta");
        Console.WriteLine("Presione enter para continuar");
        Console.ReadKey();
        Console.Clear();
    }
    }while(op < 1 || op > 4);
    Console.WriteLine("\nOpcion correcta, cargando...");
    return op;
}

//Funcion que devuelve un entero
int IngresarEntero(){
    int num;
    if(int.TryParse(Console.ReadLine(), out num)){
        return num;
    }else{
        return -1111;
    }
}

//Funcion que genera frase 
void Mensaje(Personaje atacante){
    Console.Write("\n\t\tAtaca "+ atacante.Nombre+ " utiliza "+ atacante.Abilidad+"\n");
}