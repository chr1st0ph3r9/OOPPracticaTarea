using UnityEngine;






public class PlayerMovement : MonoBehaviour
{


    public MainInputMovementSO inputReader;

    //para movimiento
    public Vector3 direccionMovimiento;
    public Vector3 vectorDelante;
    public Vector3 vectorLado;
    public float velocidadMovimiento = 10;
    public Rigidbody rb;

    //para camara
    public Transform camara;


    public int anguloMaximoRotacion = 90;
    public int anguloMinimoRotacion = -90;

    public float rotacionY;
    public float sensibilidadCamara = 5f;







    private void MovimientoCamara(Vector2 direccion)
    {
        float anguloY = sensibilidadCamara * direccion.y * Time.deltaTime;
        float anguloX = sensibilidadCamara * direccion.x * Time.deltaTime;
        float anguloXArribaAbajo = Mathf.Clamp(anguloY, anguloMinimoRotacion, anguloMaximoRotacion);

        rotacionY -= anguloXArribaAbajo;

        camara.localRotation = Quaternion.Euler(rotacionY, 0, 0);

        transform.Rotate(Vector3.up * anguloX);

    }

    private void Awake()
    {
        inputReader.eventoMoverHorizontal += movimientoBase;
        inputReader.eventoMirar += MovimientoCamara;



    }
    private void OnDisable()
    {
        inputReader.eventoMoverHorizontal -= movimientoBase;
        inputReader.eventoMirar -= MovimientoCamara;


    }
    private void FixedUpdate()
    {
        logicaMovimiento();
    }



    //movimiento de jugador
    private void movimientoBase(Vector2 direccionDeMovimiento)
    {
        vectorDelante = Vector3.ProjectOnPlane(camara.forward, Vector3.up).normalized;
        vectorLado = Vector3.ProjectOnPlane(camara.right, Vector3.up).normalized;
        direccionMovimiento = (vectorDelante * direccionDeMovimiento.y + vectorLado * direccionDeMovimiento.x).normalized;
    }

    private void logicaMovimiento()
    {
        //rb.linearVelocity
        rb.linearVelocity = (direccionMovimiento * velocidadMovimiento) * Time.fixedDeltaTime;
    }


    //movimiento de camara


}
