using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController_HD : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float speed;
    [SerializeField] private float carTorque;
    [SerializeField] private float fuel;
    [SerializeField] private float fuelConsumption;

    [Header("Dependencies")]
    [SerializeField] private Rigidbody2D carRigidBody;
    [SerializeField] private Rigidbody2D backTire;
    [SerializeField] private Rigidbody2D frontTire;

    [Header("UI")]
    [SerializeField] private Image fuelUI;

    //private
    private float horizontalMove;

    void FixedUpdate()
    {

        if (fuel > 0)
        {
            backTire.AddTorque(-horizontalMove * speed * Time.fixedDeltaTime);
            frontTire.AddTorque(-horizontalMove * speed * Time.fixedDeltaTime);
            carRigidBody.AddTorque(horizontalMove * carTorque * Time.fixedDeltaTime);
        }        

        fuel -= fuelConsumption * Mathf.Abs(horizontalMove) * Time.fixedDeltaTime;
        fuelUI.fillAmount = fuel;
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        horizontalMove = value.ReadValue<Vector2>().x;
    }
}
