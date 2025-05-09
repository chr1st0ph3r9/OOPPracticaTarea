
using UnityEngine;

public abstract class Portador : MonoBehaviour, IRecibirDamage
{
    public delegate void tipoEventoMuerte();
    public event tipoEventoMuerte eventoMorirEnemigo;



    protected SistemaVida sistemaDeVida= new SistemaVida(100,100,0);
    public void RecibirDamage(int cantidadDamage)
    {
        sistemaDeVida.CantidadActual -= cantidadDamage;
        eventoMorirEnemigo?.Invoke();
    }
}
