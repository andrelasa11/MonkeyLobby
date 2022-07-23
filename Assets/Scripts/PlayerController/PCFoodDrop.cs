using UnityEngine;
using UnityEngine.InputSystem;

public class PCFoodDrop : PlayerController
{   

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

    public override void OnMovement(InputAction.CallbackContext value)
    {
        base.OnMovement(value);
    }

    public override void Flip()
    {
        base.Flip();
    }
}
