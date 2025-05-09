using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanzaDeLuz : Habilidad, IUsar
{
    private GameObject lanzaDeLuzPrefab;
    public GameObject LanzaDeLuzPrefab { get => lanzaDeLuzPrefab; set => lanzaDeLuzPrefab = value; }
    private Transform lugarDeCreacion;
    public Transform LugarDeCreacion { get => lugarDeCreacion; set => lugarDeCreacion = value; }

    private int potencia;
    public int Potencia { get => potencia; set => potencia = value; }


    public LanzaDeLuz(int potencia) 
    {
        //GameObject lanzaDeLuz, Transform lugarDeCreacion, int potencia
        this.costoPorUso = 25;
        this.nombreHabilidad = "lanza de luz";
        this.EstaDisponible = true;
        this.tiempoDeCooldown = 3;
        this.Potencia = potencia;



    }


    public void Usar()
    {



    }
}
