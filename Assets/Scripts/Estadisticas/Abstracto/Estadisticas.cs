
public abstract class  Estadisticas 
{
    //variables privadas
    protected int cantidadActual;
    protected int cantidadMaxima;
    protected int cantidadMinima;

    //accesos
    public int CantidadActual { get => cantidadActual; set => cantidadActual = value; }

    public int CantidadMaxima { get => cantidadMaxima; set => cantidadMaxima = value; }



    public Estadisticas(int cantidadActual, int cantidadMaxima, int cantidadMinima)
    {
        this.cantidadActual = cantidadActual;
        this.cantidadMaxima = cantidadMaxima;
        this.cantidadMinima = cantidadMinima;
    }
}
