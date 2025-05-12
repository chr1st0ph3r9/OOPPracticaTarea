using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MagoOscuro : Jugable
{
    public MainInputMovementSO inputReader;

    private string _tipoMago = "mago Vida";
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




    private void Awake()
    {

        inputReader.eventoHabilidad1Iniciado += UsarHabilidadLanzaDeLuz;
        inputReader.eventoHabilidad2Iniciado += UsarHabilidadPilarArcano;

        //base.eventoCeroVida -= Destruir;


    }
    private void OnDisable()
    {
        
        inputReader.eventoHabilidad1Iniciado -= UsarHabilidadLanzaDeLuz;
        inputReader.eventoHabilidad2Iniciado -= UsarHabilidadPilarArcano;



    }
    private void Start()
    {
        nombreMago.text = _tipoMago;
        sliderDeVida.value = base.sistemaDeVida.CantidadActual;
        sliderDeMana.value = base.sistemaDeMana.CantidadActual;


        _costoHabilidadLanzaLuz = sistemaDeHabilidades.ObtenerCostoHabilidadLanzaLuz();
        _costoHabilidadPilarArcano = sistemaDeHabilidades.ObtenerCostoHabilidadPilarArcano();



    }


    private void UsarHabilidadLanzaDeLuz()
    {
        _puedeUsarLanzaLuz = sistemaDeHabilidades.ObtenerEstadoLanzaLuz();
        if (base.sistemaDeVida.CantidadActual> _costoHabilidadLanzaLuz && _puedeUsarLanzaLuz)
        {
            sistemaDeHabilidades.UsarHabilidadLanzaLuz();
            RestarCosto(_costoHabilidadLanzaLuz);
        }

    }

    private void UsarHabilidadPilarArcano()
    {
        _puedeUsarPilarArcano = sistemaDeHabilidades.ObtenerEstadoPilarArcano();
        if (base.sistemaDeVida.CantidadActual > _costoHabilidadPilarArcano && _puedeUsarPilarArcano)
        {
            sistemaDeHabilidades.UsarHabilidadPilarArcano();
            RestarCosto(_costoHabilidadPilarArcano);
        }

    }
    private void RestarCosto(int costo)
    {
        base.sistemaDeVida.CantidadActual -= costo;
        sliderDeVida.value = base.sistemaDeVida.CantidadActual;

    }



}
