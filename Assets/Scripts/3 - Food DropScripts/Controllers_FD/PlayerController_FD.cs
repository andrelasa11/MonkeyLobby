using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_FD : MonoBehaviour
{

    [Header("Configuration")]
    [SerializeField] private float speed;

    [Header("Dependencies")]
    [SerializeField] private Rigidbody2D rigidBody;

    //private
    private float horizontalMove;

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(horizontalMove * speed, rigidBody.velocity.y);
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        horizontalMove = value.ReadValue<Vector2>().x;
    }
}
