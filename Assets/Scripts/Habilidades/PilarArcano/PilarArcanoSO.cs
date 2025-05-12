using UnityEngine;
using System.Collections.Generic;



[CreateAssetMenu(fileName = "nuevo Pilar Arcano", menuName = "PilarArcanoSO")]
public class PilarArcanoSO : Habilidad, IUsar
{

    [SerializeField] private GameObject _pilarArcanoPrefab;
    private Transform _lugarCreacion;
    [SerializeField] private int _tiempoHabilidad;
    [SerializeField] private int distanciaDeJugador;
    private Vector3 direccionHabilidad;
    private GameObject pilarCreado;

    public int TiempoHabilidad { get => _tiempoHabilidad; set => _tiempoHabilidad = value; }
    public GameObject PilarCreado { get => pilarCreado; set => pilarCreado = value; }
    public Transform LugarCreacion { get => _lugarCreacion; set => _lugarCreacion = value; }

    public void Usar()
    {
        direccionHabilidad = LugarCreacion.forward*distanciaDeJugador;
        direccionHabilidad.y = 8;

        PilarCreado= Instantiate(_pilarArcanoPrefab);
        PilarCreado.transform.position =LugarCreacion.position + direccionHabilidad;
        base.CooldownHabilidadUI();
    }


    public void DestruirPilar()
    {
        Destroy(PilarCreado);
    }

}
