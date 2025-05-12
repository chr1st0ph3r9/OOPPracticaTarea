
using UnityEngine;

public abstract class Portador : MonoBehaviour, IRecibirDamage
{
    public delegate void tipoEventoMuerte();
    public event tipoEventoMuerte eventoRecibirDamage;
    private bool puedoRecibirDamage = true;


    protected SistemaVida sistemaDeVida= new SistemaVida(100,100,0);
    public void RecibirDamage(int cantidadDamage)
    {
        if (puedoRecibirDamage)
        {
            sistemaDeVida.CantidadActual -= cantidadDamage;
            eventoRecibirDamage?.Invoke();
            puedoRecibirDamage = false;
            Invoke("ActivarDamage", 1);
        }

    }
    private void ActivarDamage()
    {
        puedoRecibirDamage = true;
    }
}
