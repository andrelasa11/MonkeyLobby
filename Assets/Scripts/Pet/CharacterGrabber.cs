using UnityEngine;

public class CharacterGrabber : MonoBehaviour, IDraggable
{
    [Header("Configuration")]
    [SerializeField] private float virtualDragSpeed;

    [Header("Dependencies")]
    [SerializeField] private Transform target;
    [SerializeField] private GrabbableCharacter grabbableCharacter;

    //private
    private Camera mainCamera;
    private Vector3 velocity = Vector3.zero;
    private float initialDistance;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void OnDragStart()
    {
        target.position = InputManager.worldMousePosition;

        initialDistance = Vector3.Distance(transform.position, mainCamera.transform.position);
        Vector2 anchor = (Vector2)grabbableCharacter.transform.position - InputManager.worldMousePosition * -10;
        grabbableCharacter.Grabble(anchor);
        target.localPosition = transform.position;
    }

    public void OnDragUpdate()
    {
        Ray ray = mainCamera.ScreenPointToRay(InputManager.screenMousePosition);
        target.position = Vector3.SmoothDamp(target.position, ray.GetPoint(initialDistance), ref velocity, virtualDragSpeed);
    }

    public void OnDragEnd()
    {
        grabbableCharacter.Ungrab();
    }
}
