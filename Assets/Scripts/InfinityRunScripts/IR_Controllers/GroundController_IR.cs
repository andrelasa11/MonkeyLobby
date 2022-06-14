using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController_IR : MonoBehaviour
{

    [Header("Ground Configuration")]
    [SerializeField] private int minSize;
    [SerializeField] private int maxSize;

    [Header("Dependencies")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider;

    //private
    private float groundSize;

    private void Start()
    {
        RandomizeGroundSize();
        spriteRenderer.size = new Vector2(groundSize, 1);
        boxCollider.size = new Vector2(groundSize, 1);
    }

    #region "MyMethods"

    private void RandomizeGroundSize()
    {
        groundSize = Random.Range(minSize, maxSize);
    }

    #endregion
}
