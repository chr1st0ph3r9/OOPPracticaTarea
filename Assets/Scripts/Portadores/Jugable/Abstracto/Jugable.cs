using UnityEngine;

public class Jugable : Portador
{
    protected SistemaMana sistemaDeMana=new SistemaMana(50,100,0);

    //esta una funcion heredada de vida sistemaDeVida
    //
    // hay una funcion para recibir daño RecibirDamage

    public SistemaHabilidades sistemaDeHabilidades;
    //se debe importar sistema de habilidades

}
