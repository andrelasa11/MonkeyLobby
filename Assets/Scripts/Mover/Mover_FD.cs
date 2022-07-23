using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_FD : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody.velocity = (Vector2.down * GCFoodDrop.Instance.foodSpeed);
    }

}
