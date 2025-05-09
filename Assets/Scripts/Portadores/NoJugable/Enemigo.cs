using UnityEditor;
using UnityEngine;

public class Enemigo : Portador
{
    void Awake()
    {
        base.eventoMorirEnemigo+=Destruir;
    }
    void OnDisable()
    {
        base.eventoMorirEnemigo-=Destruir;
    }
    public void RecibirDamageEnemigo(int cantidadDeDamage){
        this.RecibirDamage(cantidadDeDamage);
    }
   public void Destruir()
    {
        if(sistemaDeVida.CantidadActual<=0)
        {
        Destroy(gameObject);
        }
    }
}
