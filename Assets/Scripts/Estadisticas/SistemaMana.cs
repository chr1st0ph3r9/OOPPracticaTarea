
public enum TipoRecarga
{
    Inmediato, PorTiempo
}
public class SistemaMana : Estadisticas
{

    public SistemaMana(int cantidadActual, int CantidadMaxima, int cantidadMinima) : base(cantidadActual, CantidadMaxima, cantidadMinima)
    {

    }

    public void IncrementoMana(TipoRecarga tipoIncremento, int cantidadAIncrementar=1)
    {
        this.cantidadActual = (tipoIncremento == TipoRecarga.PorTiempo) ? this.cantidadActual + 1 : this.cantidadActual += cantidadAIncrementar;
    }
    public void DecrementoMana(TipoRecarga tipoDecremento, int cantidadADecrementar = 1)
    {
        this.cantidadActual = (tipoDecremento == TipoRecarga.PorTiempo) ? this.cantidadActual - 1 : this.cantidadActual -= cantidadADecrementar;

    }

}
