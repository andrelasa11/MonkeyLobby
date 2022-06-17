using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController_HD : MonoBehaviour
{
    
    [Header("Dependencies")]
    [SerializeField] private List<GameObject> grounds;

    //private
    private Vector3 generationPosition;
    private int groundIndex;
    private bool isGenerating = true;

    private void Start()
    {
        generationPosition = new Vector3(this.transform.position.x + 87.9f, this.transform.position.y, this.transform.position.z);
    }

    public void GenerateGround()
    {
        if(isGenerating)
        {
            groundIndex = Random.Range(0, grounds.Count);
            Instantiate(grounds[groundIndex], generationPosition, Quaternion.identity);
            isGenerating = false;
        }
        
    }
}
