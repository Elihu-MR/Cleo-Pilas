namespace listasEnlazadas;
public class listasEnlazada{ // clase para enlazar nodos
    private Nodo primero;
    public string ciudad;
    public int contador;
    public listasEnlazada(string Ciudad){ // constructor para establecer la liga del primer elemento
        primero = null;
        ciudad = Ciudad;
        contador = 0; // Limite de la pila: 5
    }

    public void agregarAlFinal(object valor1, object valor2){ // Agregar al Final
        Nodo nuevoNodo = new Nodo (valor1, valor2);
        if (primero == null){
            primero = nuevoNodo;
        } else {
            Nodo actual = primero;
            while (actual.Siguiente != null){
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
        contador++;
    }

    public (object,  object) eliminarCima(){ // Eliminar Ultimo de la pila
        if (primero == null) return (null, null);
        Nodo auxiliar;

        if (primero.Siguiente == null){
            auxiliar = primero;
            primero = null;
            contador--;
            return (auxiliar.Valor1, auxiliar.Valor2);
        } else {
            Nodo actual = primero;
            while (actual.Siguiente.Siguiente != null){
                actual = actual.Siguiente;
            }
            auxiliar = actual.Siguiente;
            actual.Siguiente = null;
            contador--;
            return (auxiliar.Valor1, auxiliar.Valor2);
        }
    }

    public bool buscarPorValor(object valor){ // Buscar Por Valor
        Nodo actual = primero;
        while (actual != null){
            if (actual.Valor1.Equals(valor)){
                return true;
            }
            actual = actual.Siguiente;
        }
        return false;
    }


public void enlistar(int x, int  y){ // Muestra la ciudad y muestra los contenedores especificando sus posiciones y su codigo y empresa
int posicion = 1, y2=y;
Nodo actual = primero;
printxy(x, y+=1, "╔═══════════════════════════════╗");
printxy(x, y+=1, "║                               ║");
printxy(x, y+=1, "╠═══════════════════════════════╣");
printxy(x, y+=1, "║                               ║");
printxy(x, y+=1, "║                               ║");
printxy(x, y+=1, "║                               ║");
printxy(x, y+=1, "║                               ║");
printxy(x, y+=1, "║                               ║");
printxy(x, y+=1, "║                               ║");
printxy(x, y+=1, "║                               ║");
printxy(x, y+=1, "║                               ║");
printxy(x, y+=1, "╚═══════════════════════════════╝");

printxy(x+12, y2+=2, ciudad);
printxy(x+4, y2+=2, "Codigo");
printxy(x+14, y2, "Empresa");
y2+=1;
    while (actual != null ){
        printxy(x+3, y2+=1, $"{posicion}) {actual.Valor1}");
        printxy(x+14, y2, $"{actual.Valor2}");
        actual = actual.Siguiente;
        posicion++;
    }
    printxy(0,14,"");
}

public int contenedor(int x, int  y){ // Muestra todos los contenedores de la lista
Nodo actual = primero;
contador = 0;
    while (actual != null ){
        printxy(x, y+=1, "╔═══════════════════════════╗");
        printxy(x, y+=1, "║                           ║");
        printxy(x, y+=1, "╚═══════════════════════════╝");
        printxy(x+2, y-1, $"{actual.Valor1} {actual.Valor2}");
        actual = actual.Siguiente;
        contador += 3;
    }
    if (contador == 0) return 3;
    else return contador;
}

public void retirado(int x, int  y){ // Muestra Solo El Ultimo Contenedor de la lista (para mostrar contenedores retirados)
Nodo actual = primero;
    while (actual.Siguiente != null ){
        actual = actual.Siguiente;
    }
    printxy(x, y+=1, "╔═══════════════════════════╗");
    printxy(x, y+=1, "║                           ║");
    printxy(x, y+=1, "╚═══════════════════════════╝");
    printxy(x+2, y-1, $"{actual.Valor1} {actual.Valor2}");
}

public void enlistarTotales(int x, int  y){ // Muestra los contenedores actuales de cada ciudad y el total de contenedores actuales
int posicion = 1, y2=y;
Nodo actual = primero;
printxy(x, y+=1, "╔═══════════════════════════════╗");
printxy(x, y+=1, "║                               ║");
printxy(x, y+=1, "╠═══════════════════════════════╣");
printxy(x, y+=1, "║                               ║");
printxy(x, y+=1, "╚═══════════════════════════════╝");

printxy(x+12, y2+=2, ciudad);
printxy(x+8, y2+=2, $"Contenedores: {contador}");
}

    public static void printxy(int x, int y, string mensaje){
        Console.SetCursorPosition(x,y);
        Console.Write(mensaje);
    }

    public void contarElementos(){ // constructor para establecer la liga del primer elemento
        Console.WriteLine($"\n Total de elementos en la lista: {contador}\n");
    }

}