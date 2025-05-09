using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SistemaHabilidades:MonoBehaviour
{

    public List<Habilidad> listaDeHabilidades = new List<Habilidad>();




    //referencias para habilidad lanza luz
    [Header("referencias habilidad lanza de luz")]
    [SerializeField]
    private Image iconoLanzaLuz;
    [SerializeField]
    private Sprite spriteUILanzaLuz;
    [SerializeField]
    private TextMeshProUGUI nombreHabilidadLanzaLuzUI;
    [SerializeField]
    private Slider barraCooldownSliderLanzaLuzUI;
    [SerializeField]
    private GameObject lanzaLuzPrefab;
    [SerializeField]
    private Transform lugarDeCreacion;
    //info necesaria para la lanza de luz
    //iconoLanzaLuz, NombreLanzaLuzUI, barraCooldownSliderLanzaLuzUI, lanzaLuzPrefab, lugarDeCreacion,

    public LanzaDeLuz habilidadLanzaDeLuz;

    private void Awake()
    {

        enviarReferenciasHabilidadLanzaLuz();
        setearUILanzaDeLuz();



    }
    private void enviarReferenciasHabilidadLanzaLuz()
    {
        //agregando referencias de habilidad Lanza de Luz
        habilidadLanzaDeLuz.IconoHabilidad = iconoLanzaLuz;
        habilidadLanzaDeLuz.NombreHabilidadUI = nombreHabilidadLanzaLuzUI;
        habilidadLanzaDeLuz.BarraCooldownHabilidadUI = barraCooldownSliderLanzaLuzUI;
        habilidadLanzaDeLuz.LanzaDeLuzPrefab = lanzaLuzPrefab;
        habilidadLanzaDeLuz.LugarDeCreacion = lugarDeCreacion;
        habilidadLanzaDeLuz.SpriteIconoUI = spriteUILanzaLuz;
        habilidadLanzaDeLuz.Potencia = 50;
    }

    private void setearUILanzaDeLuz()
    {
        habilidadLanzaDeLuz.ActualizarUI();
    }
    public void usarHabilidadLanzaLuz()
    {
        if (habilidadLanzaDeLuz.EstaDisponible==true)
        {
            habilidadLanzaDeLuz.CooldownHabilidadUI();

            GameObject creacionDeLanza = Instantiate(habilidadLanzaDeLuz.LanzaDeLuzPrefab);
            creacionDeLanza.transform.position = lugarDeCreacion.position;
            creacionDeLanza.transform.rotation = lugarDeCreacion.rotation;

            if (creacionDeLanza.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.AddForce(lugarDeCreacion.forward * habilidadLanzaDeLuz.Potencia, ForceMode.Impulse);
            }

            habilidadLanzaDeLuz.CooldownHabilidadUI();
            Invoke("ActivarHabilidadLanzaLuz", habilidadLanzaDeLuz.TiempoDeCooldown);
        }

    }

    private void ActivarHabilidadLanzaLuz()
    {
        habilidadLanzaDeLuz.recargarCooldown();
    }
}
