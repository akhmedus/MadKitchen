using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class InputManager : MonoBehaviour
{
    private InputManagerGenerate _inputActions;

    public event EventHandler _interactActions;

    private void Awake()
    {
        _inputActions = new InputManagerGenerate();
        _inputActions.Target.Enable();

        _inputActions.Target.Interact.performed += Interact_performed;
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
