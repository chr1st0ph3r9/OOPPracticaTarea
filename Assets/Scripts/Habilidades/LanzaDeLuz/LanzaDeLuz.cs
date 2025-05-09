using TMPro;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName ="nuevo Lanza de Luz", menuName ="LanzaDeLuzSO")]
public class LanzaDeLuz : Habilidad, IUsar
{
    [SerializeField] private GameObject lanzaDeLuzPrefab;
    public GameObject LanzaDeLuzPrefab { get => lanzaDeLuzPrefab; set => lanzaDeLuzPrefab = value; }
    private Transform lugarDeCreacion;
    public Transform LugarDeCreacion { get => lugarDeCreacion; set => lugarDeCreacion = value; }
    [SerializeField]private int potencia;
    public int Potencia { get => potencia; set => potencia = value; }

    public void Usar()
    {

    }
}
