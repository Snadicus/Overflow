using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDetector : MonoBehaviour
{
    public InputSystem_Actions playerControls;

    // Listen for input
    Vector2 moveDirection = Vector2.zero;
    InputAction move;
    InputAction jump;
    InputAction interact;
    //InputAction pause;

    // Send over input once received
    public delegate void InputDelegate();
    public event InputDelegate OnJump;
    public event InputDelegate OnInteract;
    //public event InputDelegate OnPause;

    // Override input
    //InputType GetInputFrom = InputType.Player;
    //Vector3 OverrideMovementDirection;

    #region Unity Methods
    void Awake()
    {
        playerControls = new InputSystem_Actions();
    }

    void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        jump = playerControls.Player.Jump;
        jump.Enable();
        jump.performed += Jump;

        interact = playerControls.Player.Interact;
        interact.Enable();
        interact.started += Interact;

        //pause = playerControls.Player.Pause;
        //pause.Enable();
        //pause.performed += Pause;
    }

    void OnDisable()
    {
        move.Disable();
        interact.Disable();
        //pause.Disable();
    }

    // The player's movement input, detected as (x, y)
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }
    #endregion

    #region Notifiers
    // Returns movement input as (x, 0, y)
    public float GetXVelocity()
    {
        return moveDirection.x;

        /*
        if(GetInputFrom == InputType.Player)
        {
            return new Vector3(moveDirection.x, 0, moveDirection.y);
        }
        else
        {
            return OverrideMovementDirection;
        }
        */
    }

    public void Jump(InputAction.CallbackContext context)
    {
        OnJump?.Invoke();
    }

    // Notifier for interact button
    public void Interact(InputAction.CallbackContext context)
    {
        OnInteract?.Invoke();
    }

    // Notifier for pause button
    /*
    public void Pause(InputAction.CallbackContext context)
    {
        OnPause?.Invoke();
    }
    */
    #endregion

    #region Enable/Disable Detection
    public void ToggleAllDetection(bool enable)
    {
        ToggleMovementDetection(enable);
        ToggleInteractDetection(enable);
        //ToggleDetection(pause, enable);
    }

    /*
    public void ToggleCutsceneDetection(bool enable)
    {
        ToggleMovementDetection(enable);
        ToggleDetection(pause, enable);
    }
    */

    public void ToggleMovementDetection(bool enable)
    {
        ToggleDetection(move, enable);
    }

    public void ToggleInteractDetection(bool enable)
    {
        ToggleDetection(interact, enable);
    }

    void ToggleDetection(InputAction input, bool enable)
    {
        if(enable)
        {
            input.Enable();
        }
        else
        {
            input.Disable();
        }
    }
    #endregion

    /*
    #region Override Input
    public void EnableOverrideState(bool enable)
    {
        GetInputFrom = enable ? InputType.Override : InputType.Player;
    }

    public void OverrideMovement(Vector3 destination)
    {
        OverrideMovementDirection = destination;
    }
    #endregion

    #region Enums
    enum InputType
    {
        Player,
        Override
    }
    #endregion
    */
}
