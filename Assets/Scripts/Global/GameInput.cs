using System;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{

    private static GameInput _instance;

    // Public static property to access the instance
    public static GameInput Instance
    {
        get
        {
            // If the instance is null, find it in the scene or create one if it doesn't exist
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameInput>();
                if (_instance == null)
                {
                    // Create a new GameObject and attach GameInput to it
                    GameObject singletonObject = new GameObject(typeof(GameInput).Name);
                    _instance = singletonObject.AddComponent<GameInput>();
                }
            }
            return _instance;
        }
    }


    // events
    public event EventHandler OnDash;
    public event EventHandler<OnMoveArgs> OnMove;
    public class OnMoveArgs : EventArgs
    {
        public Vector2 normalizedMovement;
    }
    public event EventHandler OnStopMoving;
    public event EventHandler OnAttack;
    private PlayerInputActions input;
    private void Awake()
    {
        input = new PlayerInputActions();
        input.Player.Enable();
        input.Player.Move.performed += HandleMove;
        input.Player.Move.canceled += HandleStopMoving;
        input.Player.Attack.performed += HandleAttack;
        input.Player.Dash.performed += HandleDash;
    }
    private void HandleMove(InputAction.CallbackContext context)
    {
        OnMoveArgs args = new()
        {
            normalizedMovement = GetNormalizedMovement()
        };
        OnMove?.Invoke(this, args);
    }


    private void HandleStopMoving(InputAction.CallbackContext context) => OnStopMoving?.Invoke(this, EventArgs.Empty);

    private void HandleAttack(InputAction.CallbackContext context) => OnAttack?.Invoke(this, EventArgs.Empty);

    private void HandleDash(InputAction.CallbackContext context) => OnDash?.Invoke(this, EventArgs.Empty);

    public Vector2 GetNormalizedMovement()
    {
        Vector2 inputVector = input.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }
}