using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MagoLuz : Jugable
{

    public MainInputMovementSO inputReader;

    private string _tipoMago = "mago Mana";
    //referencias UI
    [Header("REFERENCIAS UI")]
    [SerializeField] private Slider sliderDeVida;
    [SerializeField] private Slider sliderDeMana;
    [SerializeField] private TextMeshProUGUI nombreMago;

    //info habilidad lanza de luz
    private int _costoHabilidadLanzaLuz;
    private bool _puedeUsarLanzaLuz;

    //info habilidad Pilar Arcano
    private int _costoHabilidadPilarArcano;
    private bool _puedeUsarPilarArcano;

    //info habilidad Curacion
    private int _costoHabilidadCuracion;
    private bool _puedeUsarCuracion;
    private int _cantidadCuracion;




    private void Awake()
    {

        inputReader.eventoHabilidad1Iniciado += UsarHabilidadLanzaDeLuz;
        inputReader.eventoHabilidad2Iniciado += UsarHabilidadPilarArcano;
        inputReader.eventoHabilidad3Iniciado += UsarHabilidadCuracion;
        base.eventoRecibirDamage += actualizarUIDamage;
        base.EventoRecargaMana += ActualizarManaUI;

        //base.eventoCeroVida -= Destruir;


    }
    private void OnDisable()
    {

        inputReader.eventoHabilidad1Iniciado -= UsarHabilidadLanzaDeLuz;
        inputReader.eventoHabilidad2Iniciado -= UsarHabilidadPilarArcano;
        inputReader.eventoHabilidad3Iniciado -= UsarHabilidadCuracion;

        base.eventoRecibirDamage -= actualizarUIDamage;
        base.EventoRecargaMana -= ActualizarManaUI;





    }
    private void Start()
    {
        nombreMago.text = _tipoMago;
        sliderDeVida.value = base.sistemaDeVida.CantidadActual;
        sliderDeMana.value = base.sistemaDeMana.CantidadActual;


        _costoHabilidadLanzaLuz = sistemaDeHabilidades.ObtenerCostoHabilidadLanzaLuz();
        _costoHabilidadPilarArcano = sistemaDeHabilidades.ObtenerCostoHabilidadPilarArcano();
        _costoHabilidadCuracion = sistemaDeHabilidades.ObtenerCostoHabilidadCuracion();
        _cantidadCuracion = sistemaDeHabilidades.ObtenerCantidadHabilidadCuracion();




    }


    private void UsarHabilidadLanzaDeLuz()
    {
        _puedeUsarLanzaLuz = sistemaDeHabilidades.ObtenerEstadoLanzaLuz();
        if (base.sistemaDeMana.CantidadActual > _costoHabilidadLanzaLuz && _puedeUsarLanzaLuz)
        {
            sistemaDeHabilidades.UsarHabilidadLanzaLuz();
            RestarCosto(_costoHabilidadLanzaLuz);
        }

    }

    private void UsarHabilidadPilarArcano()
    {
        _puedeUsarPilarArcano = sistemaDeHabilidades.ObtenerEstadoPilarArcano();
        if (base.sistemaDeMana.CantidadActual > _costoHabilidadPilarArcano && _puedeUsarPilarArcano)
        {
            sistemaDeHabilidades.UsarHabilidadPilarArcano();
            RestarCosto(_costoHabilidadPilarArcano);
        }

    }

    private void UsarHabilidadCuracion()
    {
        _puedeUsarCuracion = sistemaDeHabilidades.ObtenerEstadoCuracion();
        if (base.sistemaDeMana.CantidadActual > _costoHabilidadCuracion && _puedeUsarCuracion && base.sistemaDeVida.CantidadActual < base.sistemaDeVida.CantidadMaxima)
        {

            sistemaDeHabilidades.UsarHabilidadCuracion();
            sistemaDeVida.CantidadActual += _cantidadCuracion;
            RestarCosto(_costoHabilidadCuracion);
            actualizarUIDamage();
        }

    }
    private void RestarCosto(int costo)
    {
        base.sistemaDeMana.CantidadActual -= costo;
        sliderDeMana.value = base.sistemaDeMana.CantidadActual;

    }

    private void ActualizarManaUI()
    {
        sliderDeMana.value = base.sistemaDeMana.CantidadActual;
    }


    private void actualizarUIDamage()
    {
        sliderDeVida.value = base.sistemaDeVida.CantidadActual;

    }



}
