using UnityEditor;
using UnityEngine;

public class Enemigo : Portador
{
    void Awake()
    {
        base.eventoRecibirDamage += Destruir;
    }
    void OnDisable()
    {
        base.eventoRecibirDamage -= Destruir;
    }

   public void Destruir()
    {
        if(sistemaDeVida.CantidadActual<=0)
        {
        Destroy(gameObject);
        }
    }
}
