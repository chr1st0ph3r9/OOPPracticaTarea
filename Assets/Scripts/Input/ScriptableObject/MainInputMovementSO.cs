using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName ="nuevo InputReaderSO", menuName ="InputReaderSO")]
public class MainInputMovementSO : ScriptableObject,InputSystem_Actions.IPlayerActions
{




    private InputSystem_Actions inputActions;

    

    public delegate void inputAxisAction(Vector2 movimiento);

    public event inputAxisAction eventoMoverHorizontal;
    public event inputAxisAction eventoMirar;

    public delegate void inputTipoAction();

    //eventos para la habilidad 1
    public event inputTipoAction eventoHabilidad1Iniciado;

    //eventos para la habilidad 2
    public event inputTipoAction eventoHabilidad2Iniciado;

    //eventos para la habilidad 3
    public event inputTipoAction eventoHabilidad3Iniciado;









    private void OnEnable()
    {
        inputActions = new InputSystem_Actions();

        inputActions.Player.Enable();

        inputActions.Player.AddCallbacks(this);

    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }









    public void OnLook(InputAction.CallbackContext context)
    {
        eventoMirar?.Invoke(context.ReadValue<Vector2>());

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        eventoMoverHorizontal?.Invoke(context.ReadValue<Vector2>());
    }





    

    public void OnHabilidad1(InputAction.CallbackContext context)
    {

        if (context.phase == InputActionPhase.Started)
        {
            eventoHabilidad1Iniciado?.Invoke();
        }


    }

    public void OnHabilidad2(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            eventoHabilidad2Iniciado?.Invoke();
        }
    }

    public void OnHabilidad3(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            eventoHabilidad3Iniciado?.Invoke();
        }
    }
}
