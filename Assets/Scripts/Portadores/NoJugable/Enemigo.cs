using UnityEditor;
using UnityEngine;

public class Enemigo : Portador
{


   public void Destruir()
    {
        Destroy(gameObject);
        
    }

}
