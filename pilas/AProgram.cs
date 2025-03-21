// Fecha 9/3/2025
// Alumno: Moreno Ramirez Josue Elihu
// Cuatrimestre y Grupo: 4B

namespace listasEnlazadas;
public class AProgram{
public static listasEnlazada[] areas = new listasEnlazada[5];
public static listasEnlazada[] retirados = new listasEnlazada[5];

public static listasEnlazada auxiliar = new listasEnlazada("auxiliar"); // pila auxiliar donde guardar los contenedores mientras se este retirando un contenedor especifico
public static listasEnlazada Tijuana = new listasEnlazada("Tijuana");
public static listasEnlazada Tecate = new listasEnlazada("Tecate");
public static listasEnlazada TijuanaRetirados = new listasEnlazada("Tijuana"); // pila donde se coloca la informacion de los contenedores retirados
public static listasEnlazada TecateRetirados = new listasEnlazada("Tecate");

public static int contenedores=6;

static void Main(string[] args){
    areas[0] = Tijuana;
    retirados[0] = TijuanaRetirados;

    areas[1] = Tecate;
    retirados[1] = TecateRetirados;

    

    Tijuana.agregarAlFinal("TI-1", "Empresa 1");
    Tijuana.agregarAlFinal("TI-2", "Empresa 2");
    Tijuana.agregarAlFinal("TI-3", "Empresa 3");
    Tijuana.agregarAlFinal("TI-4", "Empresa 4");
    Tijuana.agregarAlFinal("TI-5", "Empresa 5");

    Tecate.agregarAlFinal("TE-6", "Empresa 1");

    menu();
} // Main

public static void titulo(string texto){
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write(texto);
    Console.ForegroundColor = ConsoleColor.Black;
}

public static void menu(){
    string lectura;
    bool repetir;
    int indice, y = 0;

    Console.BackgroundColor = ConsoleColor.White;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Clear();

    gotoxy(10, y); titulo("Contenedores");

    printxy(0, y+=2, "╔════════════════════════════════════════╗");
    printxy(0, y+=1, "║                                        ║");
    printxy(0, y+=1, "╠════════════════════════════════════════╣");
    printxy(0, y+=1, "║                                        ║");
    printxy(0, y+=1, "║                                        ║");
    printxy(0, y+=1, "║                                        ║");
    printxy(0, y+=1, "║                                        ║");
    printxy(0, y+=1, "║                                        ║");
    printxy(0, y+=1, "║                                        ║");
    printxy(0, y+=1, "║                                        ║");
    printxy(0, y+=1, "║                                        ║");
    printxy(0, y+=1, "║                                        ║");
    printxy(0, y+=1, "╚════════════════════════════════════════╝");

    y = 1;

    printxy(7, y+=2, "Opciones del menu");
    printxy(5, y+=3, "1) Registrar nueva ciudad");
    printxy(5, y+=1, "2) Agregar Contenedor");
    printxy(5, y+=1, "3) Retirar contenedor");
    printxy(5, y+=1, "4) Ver Contenedores por ciudad");
    printxy(5, y+=1, "5) Ver Contenedores totales");
    printxy(5, y+=1, "6) Contenedores retirados");
    printxy(5, y+=1, "7) Salir");

    printxy(1, y+=4, "Opcion: ");
    do {
        gotoxy(9, y);
        lectura = Console.ReadLine();
        repetir = false;

        switch (lectura){
        case "1":
            registrarCiudad();
        break;

        case "2":
            agregarContenedor();
        break;

        case "3":
            retirarContenedor();
        break;

        case "4":
            contenedoresCiudad();
        break;

        case "5":
            contenedoresTotales();
        break;

        
        case "6":
            contenedoresRetirados();
        break;

        case "7": // Terminar Programa  -----------------------------------------------------------------------------------
            Console.Clear();
            printxy(15,3,"Apagando Programa... \n\n");
            printxy(10,6,"Presione Enter Para Continuar... ");
            Console.ReadKey();
            Environment.Exit(0);
        break;

        default:
            repetir = true;
            printxy(9, y, new String(' ', lectura.Length));
        break;
        }
    } while (repetir);
    menu();
}

public static void registrarCiudad() {
    int y, pilas;
    string resp, nombreCiudad;
    bool existe;

    do {
        pilas= 0;
        y = 0;
        existe = false;
        Console.Clear();
        gotoxy(10, 0);
        titulo("Registrar Nueva Ciudad");

        for (int i = 0; i < areas.Length; i++) {
            if (areas[i] != null) pilas++;
        }

        if (pilas == 5) {
            
            Console.ForegroundColor = ConsoleColor.Red;
            printxy(5, y += 2, "No hay espacio disponible para registrar más ciudades.");
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("\n\nPresione Enter Para Continuar... ");
            Console.ReadKey();
            return;
        }

        printxy(0, y += 2, "Ingrese el nombre de la nueva ciudad: ");
        gotoxy(40, y);

        nombreCiudad = Console.ReadLine();

        for (int i = 0; i < areas.Length; i++) {
            if (areas[i] != null && areas[i].ciudad.ToLower() == nombreCiudad.ToLower()) existe = true;
        }

            if (nombreCiudad.Length > 1){
                if (existe) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    printxy(5, y+=2, $"Error: La ciudad '{nombreCiudad.ToLower()}' ya está registrada.");
                    Console.ForegroundColor = ConsoleColor.Black;
                } else {
                    listasEnlazada nuevaciudad = new listasEnlazada(nombreCiudad);
                    listasEnlazada nuevoRetirado = new listasEnlazada(nombreCiudad);
                    areas[pilas] = nuevaciudad;
                    retirados[pilas] = nuevoRetirado;
                    printxy(5, y += 2, $"Ciudad '{nombreCiudad}' registrada con éxito.");
                }
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                printxy(5, y+=2, $"Ingrese Un Nombre De ciudad Correcto");
                Console.ForegroundColor = ConsoleColor.Black;
            }

        y+=2;
        do{
            printxy(0, y, "Registrar Otra Ciudad Nueva? S/N: ");
            gotoxy(33, y);
            resp = Console.ReadLine().ToUpper();
            printxy(34, y, new String(' ', resp.Length));
        } while (resp != "S" && resp != "N") ;

    } while (resp == "S");
}


public static void agregarContenedor(){
    string perro, pelicula, resp,lectura;
    int y, opcion=0, contador;
    listasEnlazada areaSeleccionada = null;
    bool repetir;

    do{
        contador=0;
        y = 0;
        Console.Clear();
        gotoxy(10, y);
        titulo("Agregar Contenedor");

printxy(0, y+=2, "╔═══════════════════════════════╗");
printxy(0, y+=1, "║                               ║");
printxy(0, y+=1, "╠═══════════════════════════════╣");
printxy(0, y+=1, "║                               ║");
printxy(0, y+=1, "║                               ║");
printxy(0, y+=1, "║                               ║");
printxy(0, y+=1, "║                               ║");
printxy(0, y+=1, "║                               ║");
printxy(0, y+=1, "║                               ║");
printxy(0, y+=1, "╚═══════════════════════════════╝");

        printxy(5, y=3, "Areas");
        y+=1;

        for (int i =0; i < areas.Length; i++) {
            if (areas[i] != null) {
                printxy(2, y+=1, $"{i+ 1}) {areas[i].ciudad}");
                contador +=1;
            }
        }

        printxy(0, y+=6, "Ingresa El Numero De La Ciudad Donde Agregar El Contenedor: ");

        do{
            gotoxy(60, y);
            lectura = Console.ReadLine();
            if (int.TryParse(lectura, out opcion) && opcion > 0 && opcion <= contador){
                areaSeleccionada = areas[opcion-1];
            } else {
                printxy(60, y, new String(' ', lectura.Length));
            }
        } while (opcion < 1 || opcion > contador);

        if (areaSeleccionada.contador == 5) {
            
            Console.ForegroundColor = ConsoleColor.Red;
            printxy(3, y+=2, "No Se Puede Agregar Contenedor, El Area Esta Llena");
            Console.ForegroundColor = ConsoleColor.Black;
        } else {
            string codigo = $"{areaSeleccionada.ciudad.Substring(0, 2).ToUpper()}-{contenedores+1}";
            printxy(10, y+=2, $"El Contenedor Ocupara El Lugar Numero {areaSeleccionada.contador+1} En La Pila");
            printxy(10, y+=2, $"Codigo del Contenedor: {codigo}");
            printxy(0, y+=2, "Ingrese el nombre de la empresa: ");
            gotoxy(33, y);
            string empresa = Console.ReadLine();
            areaSeleccionada.agregarAlFinal(codigo, empresa);
            contenedores++;
        }

        y+=2;
        do{
            printxy(5, y, "¿Agregar Otro contenedor? S/N: ");
            gotoxy(36, y);
            resp = Console.ReadLine().ToUpper();
            printxy(34, y, new String(' ', resp.Length));
        } while (resp != "S" && resp != "N") ;

    } while (resp == "S");
}

public static void retirarContenedor(){
    string resp="",lectura,codigo="";
    int y, opcion=0, contador;
    listasEnlazada areaSeleccionada = null, retiradosSeleccionados = null;
    object valor1, valor2;
    bool encontrado;

    do{
        contador=0;
        y = 0;
        Console.Clear();
        gotoxy(10, y);
        titulo("Retirar Contenedor");

printxy(0, y+=2, "╔═══════════════════════════════╗");
printxy(0, y+=1, "║                               ║");
printxy(0, y+=1, "╠═══════════════════════════════╣");
printxy(0, y+=1, "║                               ║");
printxy(0, y+=1, "║                               ║");
printxy(0, y+=1, "║                               ║");
printxy(0, y+=1, "║                               ║");
printxy(0, y+=1, "║                               ║");
printxy(0, y+=1, "║                               ║");
printxy(0, y+=1, "╚═══════════════════════════════╝");

        printxy(5, y=3, "Areas");
        y+=1;

        for (int i =0; i < areas.Length; i++) {
            if (areas[i] != null) {
                printxy(2, y+=1, $"{i+ 1}) {areas[i].ciudad}");
                contador +=1;
            }
        }

        printxy(0, y+=6, "Ingresa El Numero De La Ciudad Donde Retirar El Contenedor: ");

        do{
            gotoxy(61, y);
            lectura = Console.ReadLine();
            if (int.TryParse(lectura, out opcion) && opcion > 0 && opcion <= contador){
                areaSeleccionada = areas[opcion-1];
                retiradosSeleccionados = retirados[opcion-1];
            } else {
                printxy(61, y, new String(' ', lectura.Length));
            }
        } while (opcion < 1 || opcion > contador);

        do {
            if (areas[opcion-1].contador > 0){
            y = 0;
            Console.Clear();
            gotoxy(7, y);
            titulo("Retirar Contenedor");

            areas[opcion-1].enlistar(0, y);
            y+=13;

            printxy(0, y, $"Ingresa El Codigo Del Contenedor a Retirar:");
            gotoxy(45, y);
            codigo = Console.ReadLine();
            encontrado = areaSeleccionada.buscarPorValor(codigo);

            if (encontrado){
                gotoxy(45, 0); titulo(areaSeleccionada.ciudad);
                gotoxy(75, 0); titulo("Retirados");
            y=0;
                do{
                    (valor1, valor2) = areaSeleccionada.eliminarCima();
                    if (valor1.Equals(codigo)){
                        Console.ForegroundColor = ConsoleColor.Red;
                        printxy(66, y+=1, "╔═══════════════════════════╗");
                        printxy(66, y+=1, "║                           ║");
                        printxy(66, y+=1, "╚═══════════════════════════╝");
                        printxy(68, y-1, $"{valor1} {valor2}");
                        Console.ForegroundColor = ConsoleColor.Black;
                    } else {
                        printxy(66, y+=1, "╔═══════════════════════════╗");
                        printxy(66, y+=1, "║                           ║");
                        printxy(66, y+=1, "╚═══════════════════════════╝");
                        printxy(68, y-1, $"{valor1} {valor2}");
                    }
                    auxiliar.agregarAlFinal(valor1, valor2);
                } while (!(valor1.Equals(codigo)));

                areaSeleccionada.contenedor(36, 0);

            y=15;

            do{
                printxy(2, y, $"Se Retirara el contendor con codigo: {codigo}");
                printxy(5, y+1, "Desea Confirmar El Retiro? S/N: ");
                gotoxy(39, y+1);
                resp = Console.ReadLine().ToUpper();
                printxy(40, y+1, new String(' ', resp.Length));
            } while (resp != "S" && resp != "N") ;

            if (resp == "S"){
                    (valor1,valor2) = auxiliar.eliminarCima();
                    retiradosSeleccionados.agregarAlFinal(valor1,valor2);

                    while (auxiliar.contador != 0){
                        (valor1, valor2) = auxiliar.eliminarCima();
                        areaSeleccionada.agregarAlFinal(valor1, valor2);
                    }

                
                
                gotoxy(7, y+=3); titulo(areaSeleccionada.ciudad);
                gotoxy(37, y); titulo("Retirado");
                
                int y2 = areaSeleccionada.contenedor(0, y);

                Console.ForegroundColor = ConsoleColor.Red;
                retiradosSeleccionados.retirado(30, y);
                Console.ForegroundColor = ConsoleColor.Black;

            y+=y2;
            } else {
                while (auxiliar.contador != 0){
                        (valor1, valor2) = auxiliar.eliminarCima();
                        areaSeleccionada.agregarAlFinal(valor1, valor2);
                }
                y+=2;
            }

            } else {
                
                Console.ForegroundColor = ConsoleColor.Red;
                printxy(5, y+=2, "No Hay Ningun Contenedor Con Ese Codigo");
                Console.ForegroundColor = ConsoleColor.Black;
                y+=1;
            }

            do{
                printxy(2, y+1, "Retirar Otro Contentedor De La Ciudad? S/N: ");
                gotoxy(46, y+1);
                resp = Console.ReadLine().ToUpper();
                printxy(47, y, new String(' ', resp.Length));
            } while (resp != "S" && resp != "N") ;
        } else {
            Console.Clear();
            y=0;
            gotoxy(10, y);
            titulo("Retirar Contenedor");

            Console.ForegroundColor = ConsoleColor.Red;
            printxy(0, y+=2, "Actualmente Esta Ciudad No Cuenta Con Contenedores");
            Console.ForegroundColor = ConsoleColor.Black;
            resp = "N";
        }

        } while (resp == "S");

        y+=2;
            do{
                printxy(3, y+1, "Desea Seguir Retirando Contenedores? S/N: ");
                gotoxy(45, y+1);
                resp = Console.ReadLine().ToUpper();
                printxy(46, y+1, new String(' ', resp.Length));
            } while (resp != "S" && resp != "N") ;

    } while (resp == "S");
}

public static void contenedoresCiudad() {
    string resp,lectura;
    int y, opcion=0, contador;
    listasEnlazada areaSeleccionada = null;
    bool repetir;

    do{
        contador=0;
        y = 0;
        Console.Clear();
        gotoxy(10, y);
        titulo("Consultar Contenedores");

        printxy(0, y+=2, "╔═══════════════════════════════╗");
        printxy(0, y+=1, "║                               ║");
        printxy(0, y+=1, "╠═══════════════════════════════╣");
        printxy(0, y+=1, "║                               ║");
        printxy(0, y+=1, "║                               ║");
        printxy(0, y+=1, "║                               ║");
        printxy(0, y+=1, "║                               ║");
        printxy(0, y+=1, "║                               ║");
        printxy(0, y+=1, "║                               ║");
        printxy(0, y+=1, "╚═══════════════════════════════╝");

        printxy(5, y=3, "Areas");
        y+=1;

        for (int i =0; i < areas.Length; i++) {
            if (areas[i] != null) {
                printxy(2, y+=1, $"{i+ 1}) {areas[i].ciudad}");
                contador +=1;
            }
        }

        printxy(0, y+=6, "Ingresa El Numero De La Ciudad Para Ver Sus Contenedores: ");

        do{
            gotoxy(59, y);
            lectura = Console.ReadLine();
            if (int.TryParse(lectura, out opcion) && opcion > 0 && opcion <= contador){
                areaSeleccionada = areas[opcion-1];
            } else {
                printxy(46, y, new String(' ', lectura.Length));
            }
        } while (opcion < 1 || opcion > contador);

        if (areas[opcion-1].contador == 0) {
            Console.ForegroundColor = ConsoleColor.Red;
            printxy(0, y+=2, "Actualmente Esta Ciudad No Cuenta Con Contenedores");
            Console.ForegroundColor = ConsoleColor.Black;
            y+=2;
        } else {
            areas[opcion-1].enlistar(0, y+=1);
            y+=14;
        }

        do{
            printxy(5, y, "Desea Ver Contenedores De Otras Ciudades? S/N: ");
            gotoxy(52, y);
            resp = Console.ReadLine().ToUpper();
            printxy(34, y, new String(' ', resp.Length));
        } while (resp != "S" && resp != "N") ;

    } while (resp == "S");
}



public static void contenedoresTotales(){
    Console.Clear();
    int x=0,y=2, contenedores_totales=0;
    titulo("Contenedores\n");

    for (int i =0; i < areas.Length; i++) {
        if (areas[i] != null) {
            contenedores_totales += areas[i].contador;
        }
    }

    printxy(15, y, $"Total de Contenedores: {contenedores_totales}");

y+=1;
    for (int i =0; i < areas.Length; i++) {
        if (areas[i] != null) {
            areas[i].enlistarTotales(x, y);
        }
        x+=33;
    }

    Console.WriteLine("\n\n\nPresione Enter Para Continuar... ");
    Console.ReadKey();
}

public static void contenedoresRetirados() {
    string resp,lectura;
    int y, opcion=0, contador;
    listasEnlazada retiradosSeleccionados = null;

    do{
        contador=0;
        y = 0;
        Console.Clear();
        gotoxy(10, y);
        titulo("Consultar Contenedores Retirados");

        printxy(0, y+=2, "╔═══════════════════════════════╗");
        printxy(0, y+=1, "║                               ║");
        printxy(0, y+=1, "╠═══════════════════════════════╣");
        printxy(0, y+=1, "║                               ║");
        printxy(0, y+=1, "║                               ║");
        printxy(0, y+=1, "║                               ║");
        printxy(0, y+=1, "║                               ║");
        printxy(0, y+=1, "║                               ║");
        printxy(0, y+=1, "║                               ║");
        printxy(0, y+=1, "╚═══════════════════════════════╝");

        printxy(5, y=3, "Areas");
        y+=1;

        for (int i =0; i < retirados.Length; i++) {
            if (retirados[i] != null) {
                printxy(2, y+=1, $"{i+ 1}) {retirados[i].ciudad}");
                contador +=1;
            }
        }

        printxy(0, y+=6, "Ingresa El Numero De La Ciudad Para Ver Sus Contenedores Retirados: ");

        do{
            gotoxy(68, y);
            lectura = Console.ReadLine();
            if (int.TryParse(lectura, out opcion) && opcion > 0 && opcion <= contador){
                retiradosSeleccionados = retirados[opcion-1];
            } else {
                printxy(69, y, new String(' ', lectura.Length));
            }
        } while (opcion < 1 || opcion > contador);

        if (retirados[opcion-1].contador == 0) {
            Console.ForegroundColor = ConsoleColor.Red;
            printxy(0, y+=2, "Actualmente Esta Ciudad No Cuenta Con Contenedores Retirados");
            Console.ForegroundColor = ConsoleColor.Black;
            y+=2;
        } else {
            retirados[opcion-1].enlistar(0, y+=1);
            y+=14;
        }

        do{
            printxy(5, y, "Desea Ver Contenedores De Otras Ciudades? S/N: ");
            gotoxy(52, y);
            resp = Console.ReadLine().ToUpper();
            printxy(53, y, new String(' ', resp.Length));
        } while (resp != "S" && resp != "N") ;

    } while (resp == "S");
}


public static void printxy(int x, int y, string mensaje){
        Console.SetCursorPosition(x,y);
        Console.Write(mensaje);
    }

    public static void gotoxy(int x, int y){
        Console.SetCursorPosition(x,y);
    } // go to xy


} //Clase Program
