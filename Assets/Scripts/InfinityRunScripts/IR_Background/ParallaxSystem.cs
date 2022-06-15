using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxSystem : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float montainSpeed;
    [SerializeField] private float treeSpeed;

    [Header("Dependencies")]
    [SerializeField] private Transform montain;
    [SerializeField] private Transform tree;

    // Update is called once per frame
    void Update()
    {

        montain.transform.position += new Vector3((montainSpeed * -1) * Time.deltaTime, 0);

        if (montain.transform.position.x < -9.75)
        {
            montain.transform.position = new Vector3(9.75f, montain.transform.position.y);
        }
        
    }
}
