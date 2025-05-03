using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName ="nuevo InputReaderSO", menuName ="InputReaderSO", order =0)]
public class MainInputMovementSO : ScriptableObject,InputSystem_Actions.IPlayerActions
{




    private InputSystem_Actions inputActions;

    

    public delegate void inputAxisAction(Vector2 movimiento);

    public event inputAxisAction eventoMoverHorizontal;
    public event inputAxisAction eventoMirar;

    public delegate void inputAtaqueAction();

    public event inputAtaqueAction eventoAtaqueIniciado;
    public event inputAtaqueAction eventoAtaqueCompletado;
    public event inputAtaqueAction eventoAtaqueCancelado;









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


    public void OnAttack(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:

                Debug.Log("empezo ataque");
                eventoAtaqueIniciado?.Invoke();

                break;

            case InputActionPhase.Performed:

                Debug.Log("completo ataque");
                eventoAtaqueCompletado?.Invoke();

                break;

            case InputActionPhase.Canceled:

                Debug.Log("cancelo ataque");
                eventoAtaqueCancelado?.Invoke();

                break;


        }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        eventoMirar?.Invoke(context.ReadValue<Vector2>());

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        eventoMoverHorizontal?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }


}
