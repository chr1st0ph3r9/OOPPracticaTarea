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

    //referencias Curacion
    [Header("referencias habilidad Curacion")]
    [SerializeField] private CuracionHabilidadSOScript habilidadCuracion;
    public CuracionHabilidadSOScript HabilidadCuracion { get => habilidadCuracion; set => habilidadCuracion = value; }
    [SerializeField] private TextMeshProUGUI nombreHabilidadCuracionUI;
    [SerializeField] private Image iconoHabilidadCuracionUI;




    private void Awake()
    {
        //envia referencias de UI a las habilidades
        enviarReferenciasHabilidadLanzaLuz();
        EnviarReferenciasHabilidadPilarArcano();
        EnviarReferenciasHabilidadCuracion();

        //coloca los valores a las referencias de UI
        habilidadLanzaDeLuz.SetearUI();
        HabilidadPilarArcano.SetearUI();
        HabilidadCuracion.SetearUI();

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




    #region habilidad curacion

    private void EnviarReferenciasHabilidadCuracion()
    {
        HabilidadCuracion.NombreHabilidadUI = nombreHabilidadCuracionUI;
        HabilidadCuracion.IconoHabilidad = iconoHabilidadCuracionUI;

    }
    public void UsarHabilidadCuracion()
    {
        if (habilidadCuracion.EstaDisponible == true)
        {
            HabilidadCuracion.Usar();
            Invoke("ActivarHabilidadCuracion", HabilidadCuracion.TiempoDeCooldown);
        }

    }
    public int ObtenerCantidadHabilidadCuracion()
    {
        return HabilidadCuracion.CantidadParaCurar;
    }

    public int ObtenerCostoHabilidadCuracion()
    {
        return HabilidadCuracion.CostoPorUso;
    }
    public bool ObtenerEstadoCuracion()
    {
        return HabilidadCuracion.EstaDisponible;

    }
    private void ActivarHabilidadCuracion()
    {
        HabilidadCuracion.recargarCooldown();
    }


    #endregion
}
