namespace listasEnlazadas;
public class Nodo{ //clase para crear un nodo
    public object Valor1{get; set;}
    public object Valor2{get; set;}
    public Nodo Siguiente {get; set;}

    

    public Nodo(object valor1, object valor2){ //constructor establecelos valores del nodo sin estblecer su liga
        Valor1 = valor1;
        Valor2 = valor2;
        Siguiente = null;
    }




} // class