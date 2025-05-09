using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MagoOscuro : Jugable
{
    public MainInputMovementSO inputReader;


    private void Awake()
    {

        inputReader.eventoHabilidad1Iniciado += UsarHabilidadLanzaDeLuz;
      



    }
    private void OnDisable()
    {
        
        inputReader.eventoHabilidad1Iniciado -= UsarHabilidadLanzaDeLuz;


    }


    private void UsarHabilidadLanzaDeLuz()
    {
        sistemaDeHabilidades.usarHabilidadLanzaLuz();

    }



}
