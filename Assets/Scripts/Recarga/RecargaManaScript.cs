using UnityEngine;

public class RecargaManaScript : MonoBehaviour
{
    private IRecargaMana objetivoRecarga;
    [SerializeField] private int cantidadPorRecargarMana = 5;

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if (other.gameObject.TryGetComponent<IRecargaMana>(out IRecargaMana objetivo))
        {
            objetivoRecarga = objetivo;
            InvokeRepeating("RecargarMana", 0, 1);

        }

    }


    private void RecargarMana()
    {
        print("esta recargando mana");
        objetivoRecarga.RecargarMana(cantidadPorRecargarMana);
    }
    private void OnTriggerExit(Collider other)
    {
        CancelInvoke("RecargarMana");
    }
}
