using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController_HD : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float speed;
    [SerializeField] private float carTorque;
    //[SerializeField] private float fuel;
    //[SerializeField] private float fuelConsumption;

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

        if (GameController_HD.Instance.fuel > 0)
        {
            backTire.AddTorque(-horizontalMove * speed * Time.fixedDeltaTime);
            frontTire.AddTorque(-horizontalMove * speed * Time.fixedDeltaTime);
            carRigidBody.AddTorque(horizontalMove * carTorque * Time.fixedDeltaTime);

            GameController_HD.Instance.fuel -= GameController_HD.Instance.fuelConsumption * Mathf.Abs(horizontalMove) * Time.fixedDeltaTime;
            GameController_HD.Instance.fuelUI.fillAmount = GameController_HD.Instance.fuel;
        }
        else
        {
            GameController_HD.Instance.NoFuelGameOver();
        }

        
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        horizontalMove = value.ReadValue<Vector2>().x;
    }

    public void DoInstaGameOver()
    {
        GameController_HD.Instance.OnGameOver();
    }
    
}
