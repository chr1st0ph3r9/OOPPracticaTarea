using UnityEngine;






public class PlayerMovement : MonoBehaviour
{


    public MainInputMovementSO inputReader;

    //para movimiento
    public Vector3 direccionMovimiento;
    public Vector2 inputDireccion;



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
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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

        inputDireccion = direccionDeMovimiento;

    }

    private void logicaMovimiento()
    {
        direccionMovimiento = (transform.forward * inputDireccion.y + transform.right * inputDireccion.x).normalized;
        //rb.linearVelocity
        rb.linearVelocity = (direccionMovimiento * velocidadMovimiento) * Time.fixedDeltaTime;
    }


    //movimiento de camara


}
