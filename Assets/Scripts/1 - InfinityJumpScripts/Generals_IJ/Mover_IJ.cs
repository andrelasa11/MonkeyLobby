using UnityEngine;

public class Mover_IJ : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody.velocity = (Vector2.down * GameController_IJ.Instance.groundSpeed);
    }

    public void FallDown()
    {
        rigidBody.velocity = (Vector2.down * (GameController_IJ.Instance.groundSpeed * 2));
    }

}
