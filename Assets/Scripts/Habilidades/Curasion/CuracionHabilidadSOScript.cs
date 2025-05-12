using UnityEngine;


[CreateAssetMenu(fileName = "nueva Curacion", menuName = "CuracionSO")]

public class CuracionHabilidadSOScript : Habilidad, IUsar
{
    [SerializeField] private int cantidadParaCurar = 10;

    public int CantidadParaCurar { get => cantidadParaCurar; set => cantidadParaCurar = value; }

    public void Usar()
    {
        base.CooldownHabilidadUI();
        //algun efecto visual XD
    }
}
