using System.Runtime.CompilerServices;
using UnityEngine;

public class DamagePilarArcano : MonoBehaviour
{
    [SerializeField] private LayerMask enemigo;
    [SerializeField] private LayerMask jugador;
    [SerializeField] private int damage=1;

    private void OnTriggerStay(Collider other)
    {

        //if (other.gameObject.layer==enemigo || other.gameObject.layer == jugador)
        //{
        //    print("esta colisionando con: " + other.gameObject.name);

            if (other.gameObject.TryGetComponent<IRecibirDamage>(out IRecibirDamage objetivo))
            {
                objetivo.RecibirDamage(damage);

            
            }
        //}
    }
}
