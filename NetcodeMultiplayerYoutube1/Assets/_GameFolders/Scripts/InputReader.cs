using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader
{
    public Vector3 Direction { get; set; }
    
    public InputReader()
    {
        GameInputActions input = new GameInputActions();

        input.Player.Move.performed += HandleOnMove;
        input.Player.Move.canceled += HandleOnMove;
        
        input.Enable();
    }

    void HandleOnMove(InputAction.CallbackContext context)
    {
        var inputDirectionVector2 = context.ReadValue<Vector2>();
        Direction = new Vector3(inputDirectionVector2.x, 0f, inputDirectionVector2.y);
    }
}