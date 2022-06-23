using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController_HD : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    [Header("Dependencies")]
    [SerializeField] private WheelJoint2D backWheel;
    [SerializeField] private WheelJoint2D frontWheel;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private AudioSource audioSource;

    [Header("UI")]
    [SerializeField] private Image fuelUI;

    //private
    [SerializeField] private float horizontalMove;

    void FixedUpdate()
    {

        if (GameController_HD.Instance.fuel > 0)
        {

            if (horizontalMove == 0f)
            {
                backWheel.useMotor = false;
                frontWheel.useMotor = false;

                audioSource.volume = 0.2f;
            }
            else
            {
                backWheel.useMotor = true;
                frontWheel.useMotor = true;

                JointMotor2D motor = new JointMotor2D { motorSpeed = -horizontalMove * speed, maxMotorTorque = 10000 };
                backWheel.motor = motor;
                frontWheel.motor = motor;

                GameController_HD.Instance.fuel -= GameController_HD.Instance.fuelConsumption * Mathf.Abs(horizontalMove) * Time.fixedDeltaTime;
                GameController_HD.Instance.fuelUI.fillAmount = GameController_HD.Instance.fuel;
                audioSource.volume = 0.7f;

                rigidBody.AddTorque(horizontalMove * rotationSpeed * Time.fixedDeltaTime);
            }
        }
        else
        {
            backWheel.useMotor = false;
            frontWheel.useMotor = false;

            GameController_HD.Instance.NoFuelGameOver();
            audioSource.volume = 0.2f;
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
