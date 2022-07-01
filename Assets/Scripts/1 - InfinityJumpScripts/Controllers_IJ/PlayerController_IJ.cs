using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_IJ : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [Header("Dependencies")]
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Animator animator;

    //private
    private float horizontalMove;
    private bool isFacingRight = true;


    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(horizontalMove * speed, rigidBody.velocity.y);

        if (rigidBody.velocity.y < 0.5)
        {
            animator.SetBool("IsFalling", true);
        }
        
        else
        {
            animator.SetBool("IsFalling", false);
        }

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

    public void DoJump()
    {
        if(rigidBody.velocity.y < -1.5f)
        {                       
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);

            AudioManager.Instance.PlayJump();
        }        
    }

    public void OnDeath()
    {
        GameController_IJ.Instance.SetPlayerLives(-1);
        AudioManager.Instance.PlayDeath();
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        isFacingRight = !isFacingRight;
    }
}
