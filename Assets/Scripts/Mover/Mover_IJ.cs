using UnityEngine;

public class Mover_IJ : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody.velocity = (Vector2.down * GCInfinityJump.Instance.platformSpeed);
    }

    public void FallDown()
    {
        rigidBody.velocity = (Vector2.down * (GCInfinityJump.Instance.platformSpeed * 2));
    }

}
