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
    [SerializeField]public LanzaDeLuz habilidadLanzaDeLuz;
    [SerializeField]private TextMeshProUGUI nombreHabilidadLanzaLuzUI;
    [SerializeField]private Transform lugarDeCreacion;
    [SerializeField]private Image IconoHabilidadLanzaLuzUi;


    

    private void Awake()
    {
        enviarReferenciasHabilidadLanzaLuz();
        SetearUILanzaDeLuz();
    }
    private void enviarReferenciasHabilidadLanzaLuz()
    {
        //agregando referencias de habilidad Lanza de Luz
        habilidadLanzaDeLuz.NombreHabilidadUI = nombreHabilidadLanzaLuzUI;
        habilidadLanzaDeLuz.LugarDeCreacion = lugarDeCreacion;
        habilidadLanzaDeLuz.IconoHabilidad=IconoHabilidadLanzaLuzUi;
    }

    private void SetearUILanzaDeLuz()
    {
        habilidadLanzaDeLuz.ActualizarUI();
    }
    public void UsarHabilidadLanzaLuz()
    {
        if (habilidadLanzaDeLuz.EstaDisponible==true)
        {
            print("usamos habilidad lanza");

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
