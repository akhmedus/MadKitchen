using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class InputManager : MonoBehaviour
{
    private InputManagerGenerate _inputActions;


    public event EventHandler _interactActions;
    public event EventHandler _secondInteractActions;

    private void Awake()
    {
        _inputActions = new InputManagerGenerate();
        _inputActions.Target.Enable();

        _inputActions.Target.SecondInteract.performed += SecondInteract_performed;
        _inputActions.Target.Interact.performed += Interact_performed;
    }

    private void SecondInteract_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _secondInteractActions?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _interactActions?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 PlayerVector() 
    {
        var playerVector = _inputActions.Target.Moving.ReadValue<Vector2>();

        playerVector = playerVector.normalized;

        return playerVector;
    }
}
