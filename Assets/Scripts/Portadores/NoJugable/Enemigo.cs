using UnityEditor;
using UnityEngine;

public class Enemigo : Portador
{
    void Awake()
    {
        base.eventoCeroVida += Destruir;
    }
    void OnDisable()
    {
        base.eventoCeroVida -= Destruir;
    }

   public void Destruir()
    {
        print("se llamo al evento para verificar si se destruye");
        if(sistemaDeVida.CantidadActual<=0)
        {
        Destroy(gameObject);
        }
    }
}
