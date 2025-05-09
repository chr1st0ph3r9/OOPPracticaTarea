
using UnityEngine;

public abstract class Portador : MonoBehaviour, IRecibirDamage
{
    SistemaVida sistemaDeVida= new SistemaVida(100,100,0);
    public void RecibirDamage(int cantidadDamage)
    {
        sistemaDeVida.CantidadActual -= cantidadDamage;
    }
}
