using UnityEngine;

public class DamageLanzaLuz : MonoBehaviour
{
    [SerializeField] private int cantidadDeDamage = 50;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Jugador")
        {
            if (collision.gameObject.TryGetComponent<Enemigo>(out Enemigo scriptEnemigo))
            {
                scriptEnemigo.RecibirDamage(cantidadDeDamage);
                
            }
            Destroy(gameObject);
        }


    }
   


}
