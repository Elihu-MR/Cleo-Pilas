namespace listasEnlazadas;
public class listasEnlazada{ // clase para enlazar nodos
    private Nodo primero;
    public string ciudad;
    public int contador; // contador de cantidad de elementos en una lista
    public listasEnlazada(string Ciudad){ // constructor para establecer la liga del primer elemento
        primero = null;
        ciudad = Ciudad;
        contador = 0; // Limite de la pila: 5
    }

// Crear pila vacia
// Regresar cantidad de elementos
// Devolver elementos de la fila
// Devolver si la pila esta vacia
// Devolver si la pila esta llena

    public void agregarAlFinal(object valor1, object valor2){ // Agregar al Final
        Nodo nuevoNodo = new Nodo (valor1, valor2);
        if (primero == null){ // si no hay elementos en la lista
            primero = nuevoNodo;
        } else {
            Nodo actual = primero;
            while (actual.Siguiente != null){ //recorre los nodos
                actual = actual.Siguiente; //pasa de actual a siguiente cada vez que no hay elementos nulos
            }
            actual.Siguiente = nuevoNodo; // asigna como nuevo nodo al nodo ingresado (tras recorrer los nodos)
        }
        contador++;
    }


    public (object,  object) eliminarCima(){ // Eliminar Ultimo Elemento
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

    public int buscarPorValorIndice(object valor){ // Buscar Por Valor
        if (primero == null){
        Nodo actual = primero;
        int i=1;
        while (actual != null){
            if (actual.Valor1.Equals(valor)){
                return i;
            }
            actual = actual.Siguiente;
            i++;
        }
        return 0;
        } else return 0;
    }

    public (object,  object) buscarPorIndice(int indice){ // Buscar Por Indice
        if (indice >= 0 && indice < contador){
            Nodo actual = primero;
            for (int i = 0; i < indice; i++){ actual = actual.Siguiente; }
            return actual != null ? (actual.Valor1, actual.Valor2) : (null, null) ;
        } else{
            Console.WriteLine("\n Indice Fuera De Rango");
            return (null, null);
        }
    }

public void enlistar(int x, int  y){ // Mostrar Lista
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

public void contenedor(int x, int  y){ // Mostrar Lista
int posicion = 1, y2=y;
Nodo actual = primero;

printxy(x, y+=1, "╔═══════════════════════════╗");
printxy(x, y+=1, "║                           ║");
printxy(x, y+=1, "╚═══════════════════════════╝");
printxy(39, y-1, $"{valor1} {valor2}");

y2+=1;
    while (actual != null ){
        printxy(x+3, y2+=1, $"{posicion}) {actual.Valor1}");
        printxy(x+14, y2, $"{actual.Valor2}");
        actual = actual.Siguiente;
        posicion++;
    }
    printxy(0,14,"");
}

public void enlistarTotales(int x, int  y){ // Mostrar Lista
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