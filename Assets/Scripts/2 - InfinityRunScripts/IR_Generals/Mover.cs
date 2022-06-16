using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody.velocity = (Vector2.left * GameController_IR.Instance.groundSpeed);
    }

}
