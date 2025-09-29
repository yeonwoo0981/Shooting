using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(fileName = "InputReader", menuName = "Input/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    private Controls _controls;
    public Vector2 MousePos { get; private set; }
    public Vector2 Movement { get; private set; }
    
    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new Controls();
        }
        _controls.Player.SetCallbacks(this);
        _controls.Player.Enable();
    }

    private void OnDisable()
    {
        _controls.Player.Disable();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();
    }

    public void OnMouse(InputAction.CallbackContext context)
    {
        MousePos = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("마클");
        }
        if (context.canceled)
        {
            Debug.Log("마뗌");
        }
    }
}
