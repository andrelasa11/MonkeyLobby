using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_IJ : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

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

    public void DoJump()
    {
        if(rigidBody.velocity.y < -1.5f)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        }        
    }

    public void OnDeath()
    {
        GameController_IJ.Instance.SetPlayerLives(-1);
    }
}
