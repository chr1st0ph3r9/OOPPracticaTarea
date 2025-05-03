using UnityEngine;

public class Reto1 : MonoBehaviour
{

    public Vector2 objeto1 = new Vector2(4, 6);
    public Vector2 objeto2 = new Vector2(14, 8);

    public Vector3 ubicacionY = new Vector3(0,1,0);
    public Vector3 ubicacionYFinal = new Vector3(0, 1, 0);

    public float tiempoDeMovimiento = 0f;

    public float velocidadClamp = 0f;
    public float velocidadActual = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
    private void Update()
    {
        ClampDeVelocidad();
    }
    private void NumeroAzar()
    {
        int numeroMinimo = -10;
        int numeroMaximo = 10;

        int numeroAzar = Random.Range(numeroMinimo, numeroMaximo);
        int numeroAzarAbsoluto = Mathf.Abs(numeroAzar);

        print(numeroAzarAbsoluto);
    }

    private void MovimientoPingPong()
    {
        transform.position =new Vector3( Mathf.PingPong(10-Time.time, 20*2),2,0);

    }

    private void movimientoLerp()
    {
        tiempoDeMovimiento += 0.1f * Time.deltaTime;
        ubicacionY.y = Mathf.Lerp(1f, 10f, tiempoDeMovimiento);
        transform.position = ubicacionY;
        
    }

    private void ClampDeVelocidad()
    {
        velocidadActual++;
        velocidadClamp=Mathf.Clamp(velocidadActual,0f,5f);
        print("velocidad actual es: " + velocidadActual +" y la velocidad con clamp es: "+ velocidadClamp);
    }

}
