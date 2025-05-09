
public class SistemaVida : Estadisticas
{
    public SistemaVida(int cantidadActual, int CantidadMaxima, int cantidadMinima) : base(cantidadActual, CantidadMaxima, cantidadMinima)
    {

    }

    public void RecibirCurasion(int cantidad)
    {
        if (cantidadActual < cantidadMaxima)
        {
            this.cantidadActual += cantidad;
        }
        
    }

}
