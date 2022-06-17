using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_HD : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float speed;
    [SerializeField] private float carTorque;

    [Header("Dependencies")]
    [SerializeField] private Rigidbody2D carRigidBody;
    [SerializeField] private Rigidbody2D backTire;
    [SerializeField] private Rigidbody2D frontTire;

    //private
    private float horizontalMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        backTire.AddTorque(-horizontalMove * speed * Time.fixedDeltaTime);
        frontTire.AddTorque(-horizontalMove * speed * Time.fixedDeltaTime);
        carRigidBody.AddTorque(horizontalMove * carTorque * Time.fixedDeltaTime);
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        horizontalMove = value.ReadValue<Vector2>().x;
    }
}
