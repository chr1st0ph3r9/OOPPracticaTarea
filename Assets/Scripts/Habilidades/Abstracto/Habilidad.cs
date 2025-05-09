using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Habilidad :ScriptableObject
{

    protected int costoPorUso;
    protected string nombreHabilidad;

    private bool estaDisponible;
    protected int tiempoDeCooldown;
    protected Color colorHabilidadNoDisponible = new Color(1, 1, 1, 0.5f);
    protected Color colorHabilidadDisponible = new Color(1, 1, 1, 1);

    [SerializeField]
    protected Image iconoHabilidad;
    public Image IconoHabilidad { get => iconoHabilidad; set => iconoHabilidad = value; }

    [SerializeField]
    protected Sprite spriteIconoUI;
    public Sprite SpriteIconoUI { get => spriteIconoUI; set => spriteIconoUI = value; }


    protected TextMeshProUGUI nombreHabilidadUI;
    public TextMeshProUGUI NombreHabilidadUI { get => nombreHabilidadUI; set => nombreHabilidadUI = value; }

 
    protected Slider barraCooldownHabilidadUI;
    public Slider BarraCooldownHabilidadUI { get => barraCooldownHabilidadUI; set => barraCooldownHabilidadUI = value; }
    public bool EstaDisponible { get => estaDisponible; set => estaDisponible = value; }
    public int TiempoDeCooldown { get => tiempoDeCooldown; set => tiempoDeCooldown = value; }



    //protected Habilidad (int costoPorUso, string nombreHabilidad,  bool estaDisponible, int tiempoDeCooldown)
    //{
    //    this.costoPorUso = costoPorUso;
    //    this.nombreHabilidad = nombreHabilidad;
    //    this.estaDisponible = estaDisponible;
    //    this.tiempoDeCooldown = tiempoDeCooldown;

    //}


    //usar al inicio del juego
    public void ActualizarUI()
    {
        nombreHabilidadUI.text = nombreHabilidad;
        IconoHabilidad.sprite = SpriteIconoUI;
        
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
