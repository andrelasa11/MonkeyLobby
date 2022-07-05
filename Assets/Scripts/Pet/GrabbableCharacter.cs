using UnityEngine;
using UnityEngine.U2D.IK;

public class GrabbableCharacter : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private FixedJoint2D springJoint;
    [SerializeField] private IKManager2D iKManager2D;
    [SerializeField] private Animator animator;

    //private
    private Rigidbody2D rb;
    private Vector3 initialPosition;
    private Vector3 initialRotation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        initialRotation = transform.eulerAngles;
        initialPosition = transform.position;
    }

    public void Grabble(Vector2 anchor)
    {
        rb.isKinematic = false;
        springJoint.anchor = anchor;
        springJoint.enabled = true;
        iKManager2D.enabled = false;

        animator.Rebind();
        animator.Update(0f);
        animator.enabled = false;
    }

    public void Ungrab()
    {
        springJoint.enabled = false;
        iKManager2D.enabled = true;
        animator.enabled = true;

        transform.position = initialPosition;
        transform.eulerAngles = initialRotation;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
        rb.isKinematic = true;
    }
}
