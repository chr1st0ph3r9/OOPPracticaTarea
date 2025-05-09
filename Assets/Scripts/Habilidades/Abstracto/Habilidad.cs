using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Habilidad :ScriptableObject
{

    [SerializeField] protected int costoPorUso;
    [SerializeField] protected string nombreHabilidad;
    [SerializeField] protected int tiempoDeCooldown;

    
    public int TiempoDeCooldown { get => tiempoDeCooldown; set => tiempoDeCooldown = value; }
    [SerializeField] protected Color colorHabilidadNoDisponible = new Color(1, 1, 1, 0.5f);
    [SerializeField] protected Color colorHabilidadDisponible = new Color(1, 1, 1, 1);
    protected Image iconoHabilidad;
    public Image IconoHabilidad { get => iconoHabilidad; set => iconoHabilidad = value; }
    [SerializeField]protected Sprite spriteIconoUI;
    protected TextMeshProUGUI nombreHabilidadUI;
    public TextMeshProUGUI NombreHabilidadUI { get => nombreHabilidadUI; set => nombreHabilidadUI = value; }
    private bool estaDisponible;
    public bool EstaDisponible { get => estaDisponible; set => estaDisponible = value; }




    //usar al inicio del juego
    public void ActualizarUI()
    {
        nombreHabilidadUI.text = nombreHabilidad;
        IconoHabilidad.sprite = spriteIconoUI;
        EstaDisponible=true;
    }

    //llamar al usar la habilidad
    public void CooldownHabilidadUI()
    {
        nombreHabilidadUI.color = colorHabilidadNoDisponible;
        iconoHabilidad.color = colorHabilidadNoDisponible;

        estaDisponible = false;

    }

    //llamar al final del cooldown para poner la habilidad disponible
    public void recargarCooldown()
    {
        nombreHabilidadUI.color = colorHabilidadDisponible;
        iconoHabilidad.color = colorHabilidadDisponible;

        estaDisponible = true;
    }
}
