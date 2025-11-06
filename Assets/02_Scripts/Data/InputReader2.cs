using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _02_Scripts.Data
{
    public class InputReader2 : MonoBehaviour, Controls2.IPlayerActions
    {
        public Controls2 controls2;
        
        public Vector2 Movement { get; private set; }
        public Vector2 MousePos { get; private set; }

        public Action OnMousePressed;
        public Action OnMouseReleased;
        
        private void Awake()
        {
            if (controls2 == null)
            {
                controls2 = new Controls2();
            }
            controls2.Player.SetCallbacks(this);
            controls2.Player.Enable();
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            Movement = context.ReadValue<Vector2>();
        }

        public void OnMousePos(InputAction.CallbackContext context)
        {
            MousePos = context.ReadValue<Vector2>();
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnMousePressed?.Invoke();
            }

            if (context.canceled)
            {
                OnMouseReleased?.Invoke();
            }
        }

        private void OnDisable()
        {
            controls2.Player.Disable();
        }
    }
}