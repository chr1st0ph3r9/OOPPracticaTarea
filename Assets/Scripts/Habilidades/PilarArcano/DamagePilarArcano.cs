using UnityEngine;

public class DamagePilarArcano : MonoBehaviour
{
    public LayerMask enemigo;
    public LayerMask jugador;

    private void OnTriggerStay(Collider other)
    {

        //if (other.gameObject.layer==enemigo || other.gameObject.layer == jugador)
        //{
        //    print("esta colisionando con: " + other.gameObject.name);

            if (other.gameObject.TryGetComponent<IRecibirDamage>(out IRecibirDamage objetivo))
            {
                objetivo.RecibirDamage(1);
                print("esta haciendo 1 de daño a: " + objetivo);
            }
        //}
    }
}
