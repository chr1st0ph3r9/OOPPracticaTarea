using UnityEngine;

public class Jugable : Portador, IRecargaMana
{

    public delegate void tipoEventoRecargaMana();
    public event tipoEventoRecargaMana EventoRecargaMana;
    protected SistemaMana sistemaDeMana=new SistemaMana(50,100,0);

    //esta una funcion heredada de vida sistemaDeVida
    //
    // hay una funcion para recibir daño RecibirDamage

    public SistemaHabilidades sistemaDeHabilidades;



    public void RecargarMana(int cantidadPorRecargar)
    {
        if (sistemaDeMana.CantidadActual < sistemaDeMana.CantidadMaxima)
        {
            print("se recarga: " + cantidadPorRecargar + " y el mana es: " + sistemaDeMana.CantidadActual);
            sistemaDeMana.CantidadActual += cantidadPorRecargar;
            EventoRecargaMana?.Invoke();
        }

    }
    //se debe importar sistema de habilidades

}
