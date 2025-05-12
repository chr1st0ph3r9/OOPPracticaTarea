using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SistemaHabilidades:MonoBehaviour
{

    public List<Habilidad> listaDeHabilidades = new List<Habilidad>();

    //generico para habilidades

    //referencias para habilidad lanza luz
    [Header("referencias habilidad lanza de luz")]
    [SerializeField]private LanzaDeLuz habilidadLanzaDeLuz;
    [SerializeField]private TextMeshProUGUI nombreHabilidadLanzaLuzUI;
    [SerializeField]private Image iconoHabilidadLanzaLuzUi;
    [SerializeField] private Transform lugarDeCreacionLanzaLuz;


    public LanzaDeLuz HabilidadLanzaDeLuz { get => habilidadLanzaDeLuz; set => habilidadLanzaDeLuz = value; }
    
    //referencias pilar arcano
    [Header("referencias habilidad Pilar arcano")]
    [SerializeField] private PilarArcanoSO _habilidadPilarArcano;
    public PilarArcanoSO HabilidadPilarArcano { get => _habilidadPilarArcano; set => _habilidadPilarArcano = value; }
    [SerializeField] private TextMeshProUGUI nombreHabilidadPilarArcanoUI;
    [SerializeField] private Image iconoHabilidadPilarArcanoUI;
    [SerializeField] private Transform lugarDeCreacionPilarArcano;

    private int _tiempoPilarArcano;



    private void Awake()
    {
        //envia referencias de UI a las habilidades
        enviarReferenciasHabilidadLanzaLuz();
        EnviarReferenciasHabilidadPilarArcano();

        //coloca los valores a las referencias de UI
        habilidadLanzaDeLuz.SetearUI();
        HabilidadPilarArcano.SetearUI();

        _tiempoPilarArcano = HabilidadPilarArcano.TiempoHabilidad;
    }


    #region Habilidad lanza De Luz
    private void enviarReferenciasHabilidadLanzaLuz()
    {
        //agregando referencias de habilidad Lanza de Luz
        habilidadLanzaDeLuz.NombreHabilidadUI = nombreHabilidadLanzaLuzUI;
        habilidadLanzaDeLuz.LugarDeCreacion = lugarDeCreacionLanzaLuz;
        habilidadLanzaDeLuz.IconoHabilidad=iconoHabilidadLanzaLuzUi;



    }

    public void UsarHabilidadLanzaLuz()
    {
        if (habilidadLanzaDeLuz.EstaDisponible==true)
        {
            habilidadLanzaDeLuz.Usar();
            Invoke("ActivarHabilidadLanzaLuz", habilidadLanzaDeLuz.TiempoDeCooldown);
        }

    }
    public int ObtenerCostoHabilidadLanzaLuz()
    {
        return habilidadLanzaDeLuz.CostoPorUso;

    }
    public bool ObtenerEstadoLanzaLuz()
    {
        return habilidadLanzaDeLuz.EstaDisponible;

    }

    private void ActivarHabilidadLanzaLuz()
    {
        habilidadLanzaDeLuz.recargarCooldown();
    }
    #endregion


    #region Habilidad Pilar Arcano

    private void EnviarReferenciasHabilidadPilarArcano()
    {
        //agregar referencias habilidad Pilar arcano
        HabilidadPilarArcano.NombreHabilidadUI = nombreHabilidadPilarArcanoUI;
        HabilidadPilarArcano.IconoHabilidad = iconoHabilidadPilarArcanoUI;
        HabilidadPilarArcano.LugarCreacion = lugarDeCreacionPilarArcano;
    }
    public void UsarHabilidadPilarArcano()
    {
        if (HabilidadPilarArcano.EstaDisponible == true)
        {
            print("la habilidad pilar arcano esta disponible: "+HabilidadPilarArcano.EstaDisponible);
            HabilidadPilarArcano.Usar();
            Invoke("ActivarHabilidadPilarArcano", HabilidadPilarArcano.TiempoDeCooldown);
            Invoke("DestruirPilarArcano", _tiempoPilarArcano);
        }

    }
    private void DestruirPilarArcano()
    {
        HabilidadPilarArcano.DestruirPilar();
    }
    public int ObtenerCostoHabilidadPilarArcano()
    {
        return HabilidadPilarArcano.CostoPorUso;

    }
    public bool ObtenerEstadoPilarArcano()
    {
        return HabilidadPilarArcano.EstaDisponible;

    }

    private void ActivarHabilidadPilarArcano()
    {
        HabilidadPilarArcano.recargarCooldown();
    }


    #endregion
}
