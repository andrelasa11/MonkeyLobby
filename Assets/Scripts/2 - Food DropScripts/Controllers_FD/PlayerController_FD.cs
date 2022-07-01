using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_FD : MonoBehaviour
{

    [Header("Configuration")]
    [SerializeField] private float speed;
    [SerializeField] private bool isFacingRight = true;

    [Header("Dependencies")]
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Animator animator;

    //private
    private float horizontalMove;

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(horizontalMove * speed, rigidBody.velocity.y);

        if (horizontalMove != 0)
        {
            animator.SetBool("Run", true);
        }
        else animator.SetBool("Run", false);

        if (horizontalMove > 0 && !isFacingRight)
        {
            Flip();
        }
        
        if (horizontalMove < 0 && isFacingRight)
        {
            Flip();
        }
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        horizontalMove = value.ReadValue<Vector2>().x;
                
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        isFacingRight = !isFacingRight;
    }
}
