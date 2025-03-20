// Fecha 9/3/2025
// Alumno: Moreno Ramirez Josue Elihu
// Cuatrimestre y Grupo: 4B

namespace listasEnlazadas;
public class AProgram{
public static listasEnlazada[] areas = new listasEnlazada[5];
public static listasEnlazada Tijuana = new listasEnlazada("Tijuana");
public static listasEnlazada Tecate = new listasEnlazada("Tecate");
public static listasEnlazada Rosarito = new listasEnlazada("Rosarito");
public static listasEnlazada auxiliar = new listasEnlazada("auxiliar"); // pila auxiliar donde guardar los contenedores mientras se este retirando un contenedor especifico
public static listasEnlazada retirados = new listasEnlazada("Retirados"); // pila donde se coloca la informacion de los contenedores retirados

public static int contenedores=6;

static void Main(string[] args){
    areas[0] = Tijuana;
    areas[1] = Tecate;
    areas[2] = Rosarito;

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
    Console.ResetColor();
}

public static void menu(){
    string lectura;
    bool repetir;
    int indice, y = 0;

    Console.Clear();
    gotoxy(10, y);
    titulo("Contenedores");


    printxy(7, y+=2, "Opciones del menu");
    printxy(5, y+=2, "1) Registrar nueva ciudad");
    printxy(5, y+=1, "2) Agregar Contenedor");
    printxy(5, y+=1, "3) Retirar contenedor");
    printxy(5, y+=1, "4) Ver Contenedores por ciudad");
    printxy(5, y+=1, "5) Ver Contenedores totales");
    printxy(5, y+=1, "6) Contenedores retirados");
    printxy(5, y+=1, "7) Salir");

    printxy(1, y+=2, "Opcion: ");
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
        titulo("Registrar Nueva Ciudad");

        for (int i = 0; i < areas.Length; i++) {
            if (areas[i] != null) pilas++;
        }

        if (pilas == 5) {
            printxy(5, y += 2, "No hay espacio disponible para registrar más ciudades.");

            Console.WriteLine("\n\nPresione Enter Para Continuar... ");
            Console.ReadKey();
            return;
        }

        printxy(5, y += 2, "Ingrese el nombre de la nueva ciudad: ");
        gotoxy(43, y);

        nombreCiudad = Console.ReadLine();

        for (int i = 0; i < areas.Length; i++) {
            if (areas[i] != null && areas[i].ciudad.ToLower() == nombreCiudad.ToLower()) existe = true;
        }

        if (existe) {
            printxy(5, y+=2, $"Error: La ciudad '{nombreCiudad.ToLower()}' ya está registrada.");
        } else {
            areas[pilas] = new listasEnlazada(nombreCiudad);
            printxy(5, y += 2, $"Ciudad '{nombreCiudad}' registrada con éxito.");
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

        printxy(5, y+=2, "Areas");
        y+=1;

        for (int i =0; i < areas.Length; i++) {
            if (areas[i] != null) {
                printxy(2, y+=1, $"{i+ 1}) {areas[i].ciudad}");
                contador +=1;
            }
        }

        printxy(0, y+=2, "Ingresa El Numero De La Ciudad Donde Agregar El Contenedor: ");

        do{
            gotoxy(46, y);
            lectura = Console.ReadLine();
            if (int.TryParse(lectura, out opcion) && opcion > 0 && opcion <= contador){
                areaSeleccionada = areas[opcion-1];
            } else {
                printxy(46, y, new String(' ', lectura.Length));
            }
        } while (opcion < 1 || opcion > contador);

        if (areaSeleccionada.contador == 5) {
            printxy(3, y+=2, "No Se Puede Agregar Contenedor, El Area Esta Llena");
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
    string resp,lectura,codigo;
    int y, opcion=0, contador;
    listasEnlazada areaSeleccionada = null;
    object valor1, valor2;
    bool encontrado;

    do{
        contador=0;
        y = 0;
        Console.Clear();
        gotoxy(10, y);
        titulo("Retirar Contenedor");

        printxy(5, y+=2, "Areas");
        y+=1;

        for (int i =0; i < areas.Length; i++) {
            if (areas[i] != null) {
                printxy(2, y+=1, $"{i+ 1}) {areas[i].ciudad}");
                contador +=1;
            }
        }

        printxy(0, y+=2, "Ingresa El Numero De La Ciudad Donde Retirar El Contenedor: ");

        do{
            gotoxy(61, y);
            lectura = Console.ReadLine();
            if (int.TryParse(lectura, out opcion) && opcion > 0 && opcion <= contador){
                areaSeleccionada = areas[opcion-1];
            } else {
                printxy(46, y, new String(' ', lectura.Length));
            }
        } while (opcion < 1 || opcion > contador);

        if (areas[opcion-1].contador > 0){
            y = 0;
            Console.Clear();
            gotoxy(10, y);
            titulo("Retirar Contenedor");

            areas[opcion-1].enlistar(0, y+=1);
            y+=14;

            printxy(0, y, $"Ingresa El Codigo Del Contenedor a Retirar:");
            gotoxy(45, y);
            codigo = Console.ReadLine();
            encontrado = areaSeleccionada.buscarPorValor(codigo);
            y=1;

            if (encontrado){
                do{
                    (valor1, valor2) = areaSeleccionada.eliminarCima();
                    printxy(37, y+=1, "╔═══════════════════════════╗");
                    printxy(37, y+=1, "║                           ║");
                    printxy(37, y+=1, "╚═══════════════════════════╝");
                    printxy(39, y-1, $"{valor1} {valor2}");
                    auxiliar.agregarAlFinal(valor1, valor2);
                } while (!(valor1.Equals(codigo)));

                

                (valor1,valor2) = auxiliar.eliminarCima();
                retirados.agregarAlFinal(valor1,valor2);

                Console.WriteLine($"\nContenedor: {valor1} de {valor2} retirado");

                while (auxiliar.contador != 0){
                    (valor1, valor2) = auxiliar.eliminarCima();
                    Console.WriteLine($"\n{valor1} {valor2}");
                    areaSeleccionada.agregarAlFinal(valor1, valor2);
                }

            } else {
                printxy(0, y+=1, "No Hay Ningun Contenedor Con Ese Codigo");
            }

        } else {
            printxy(0, y+=2, "Actualmente Esta Ciudad No Cuenta Con Contenedores");
        }

        y+=2;
        do{
            //printxy(5, y, "¿Agregar Otro contenedor? S/N: ");
            gotoxy(36, y);
            resp = Console.ReadLine().ToUpper();
            printxy(34, y, new String(' ', resp.Length));
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

        printxy(5, y+=2, "Areas");
        y+=1;

        for (int i =0; i < areas.Length; i++) {
            if (areas[i] != null) {
                printxy(2, y+=1, $"{i+ 1}) {areas[i].ciudad}");
                contador +=1;
            }
        }

        printxy(0, y+=2, "Ingresa El Numero De La Ciudad Para Ver Sus Contenedores: ");

        do{
            gotoxy(59, y);
            lectura = Console.ReadLine();
            if (int.TryParse(lectura, out opcion) && opcion > 0 && opcion <= contador){
                areaSeleccionada = areas[opcion-1];
            } else {
                printxy(46, y, new String(' ', lectura.Length));
            }
        } while (opcion < 1 || opcion > contador);

        areas[opcion-1].enlistar(0, y+=1);

        y+=14;
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


public static void printxy(int x, int y, string mensaje){
        Console.SetCursorPosition(x,y);
        Console.Write(mensaje);
    }

    public static void gotoxy(int x, int y){
        Console.SetCursorPosition(x,y);
    } // go to xy


} //Clase Program
